using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Models.Classes;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Models.View;
using DerivSmartRobot.Redis;
using Newtonsoft.Json;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Services
{
    public class TradeService : ITradeService
    {
        public OperationInfo currentOperation { get; set; }
        public RobotConfigutarion RobotConfigutarion { get; set; }

        private readonly IClientDeriv _client;
        public bool HasOpenContract { get; set; } = false;

        public List<Quote> QuotesCached { get; set; }

        public ListView.ListViewItemCollection ListViewItems;

        private ContractType LastContractBought { get; set; }

        private string LastDurationType { get; set; }

        private int LastDuration { get; set; }

        public OperationView Operation { get; set; }

        public LogView Log { get; set; }
        public Guid CandleSubscriptionId { get; set; }

        public List<ResponseMessage> LogsResponse { get; set; }

        public TradeService(IClientDeriv client)
        {
            _client = client;
        }

        public bool SetConfigurationAndConnect(string token)
        {
            _client.SetConfigurations("1089", token);
            _client.Connect();
            _client.Authorize();
            return true;
        }

        public bool MakeAProposal(ContractType contractType, int duration, string durationUnit, string? barrier = null)
        {
            if (HasOpenContract)
                return true;

            HasOpenContract = true;

            var amount = Convert.ToDecimal(string.Format("{0:F2}", currentOperation.NewAmount != 0 ? currentOperation.NewAmount : RobotConfigutarion.Stake));
            var contract = CommandsService.GetCommands(CommandsApi.Proposal,
                CommandsService.BuildContractModel(1, amount, barrier, "stake", contractType.ToString(),
                    "USD", duration, durationUnit, RobotConfigutarion.Market));

            LastContractBought = contractType;
            LastDurationType = durationUnit == "t" ? "Tick" : durationUnit == "s" ? "Segundos" : durationUnit == "m" ? "Minuto" : "";
            LastDuration = duration;

            _client.SendCommand(contract);

            return true;
        }



        public bool BuyAContract(Proposal proposal)
        {
            if ((proposal.AskPrice * -1) + (double)currentOperation.CurrentOperationBalance > (double)RobotConfigutarion.StopLoss)
            {
                Console.WriteLine("STOPLOSS alcançado");
                return true;
            }

            if (currentOperation.CurrentOperationBalance >= RobotConfigutarion.StopWin)
            {
                Console.WriteLine("STOPWIN alcançado");
                return true;
            }

            Log = new LogView {Date = DateTime.Now, Log = "Realizando compra"};
            var buy = CommandsService.GetCommands(CommandsApi.Buy, proposal);
            _client.SendCommand(buy);
            return true;
        }

        public void UpdateOperationInfoValues(ResponseMessage responseMessage)
        {

            
            Operation = new OperationView
            {
                ContractId = responseMessage.OpenContract.ContractId.ToString(),
                Market = responseMessage.OpenContract.DisplayName,
                Contract = LastContractBought,
                Amount = (decimal)responseMessage.OpenContract.BuyPrice,
                Duration = LastDuration,
                DurationType = LastDurationType,
                Profit = (decimal)responseMessage.OpenContract.Profit,
                Expiration = UnixTimeStampToDateTime(responseMessage.OpenContract.ExpiryTime),
                Status = "open"

            };


            
            

            if (currentOperation.LossToRecover > 0 && RobotConfigutarion.CalledFrom != null)
            {
                RobotConfigutarion.RobotType = RobotConfigutarion.CalledFrom.Value;
                RobotConfigutarion.CalledFrom = null;
            }

            if (responseMessage.OpenContract.Status == "lost" || (responseMessage.OpenContract.Status == "sold" &&
                                                                  responseMessage.OpenContract.Profit < 0)
                                                              || (responseMessage.OpenContract.IsExpired  &&
                                                                  responseMessage.OpenContract.Profit < 0))
            {
                Operation.Profit = (decimal)responseMessage.OpenContract.Profit;
                Operation.Action = ContractAction.Sell;
                Operation.Status = "lost";
                currentOperation.LastValueLost = (decimal)responseMessage.OpenContract.Profit *-1;


                currentOperation.QuantLoss += 1;
                currentOperation.LossToRecover += currentOperation.LastValueLost;
                currentOperation.CurrentOperationBalance += currentOperation.LastValueLost *-1;
                if(responseMessage != null)
                   _client.Forget(responseMessage.Subscription.Id.ToString());
                
                HasOpenContract = false;
                return;
            }
            else if (responseMessage.OpenContract.Status == "won" || (responseMessage.OpenContract.Status == "sold" &&
                                                                      responseMessage.OpenContract.Profit > 0)
                                                                  || (responseMessage.OpenContract.IsExpired &&
                                                                      responseMessage.OpenContract.Profit > 0))
            {
                currentOperation.QuantWin += 1;
                currentOperation.LossToRecover = 0;
                Operation.Status = "won";

                currentOperation.CurrentOperationBalance += (decimal)responseMessage.OpenContract.Profit;
                Operation.Profit = (decimal) responseMessage.OpenContract.Profit;
                Operation.Action = ContractAction.Sell;
                currentOperation.LastValueLost = 0;
                _client.Forget(responseMessage?.Subscription?.Id.ToString());
                HasOpenContract = false;
                return;
            }
            else
            {
                if (LogsResponse == null)
                    LogsResponse = new List<ResponseMessage>();

                LogsResponse.Add(responseMessage);
            }

            try
            {
                currentOperation.RobotAccuracy = (currentOperation.QuantWin * 100) /
                                                 (currentOperation.QuantLoss + currentOperation.QuantWin);
            }
            catch (Exception e)
            {
             

                Console.WriteLine(e);
            }

            
            //if ((responseMessage.OpenContract.ProfitPercentage > 80 || responseMessage.OpenContract.ProfitPercentage < -20) && responseMessage.OpenContract.IsValidToSell)
            //{
            //    _client.Sell(responseMessage.OpenContract.ContractId, responseMessage.OpenContract.Profit + responseMessage.OpenContract.BuyPrice);
            //    return;
            //}
        }


        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        public ModelToView GetOperations()
        {

            return new ModelToView
            {
                Operation = Operation == null ? null : new OperationView
                {
                    ContractId = Operation.ContractId,
                    Action = Operation.Action,
                    Amount = Operation.Amount,
                    Market = Operation.Market,
                    Contract = Operation.Contract,
                    Profit = Operation.Profit,
                    Duration = Operation.Duration,
                    DurationType = Operation.DurationType,
                    Expiration = Operation.Expiration,
                    Status = Operation.Status
                },
                RobotConfigutarion = this.RobotConfigutarion,
                OperationInfo = this.currentOperation,
                Log = Log
            };
            this.Log = null;
        }

        public void UpdateBalance(ResponseMessage responseMessage)
        {
            currentOperation.Balance = responseMessage.Balance.BalanceDeriv;
        }

        public void StopOperation()
        {
            _client.UnsubscribeSucessEvents();
            _client.UnsubscribeErrosEvents();
            _client.Stop();
        }

        public void SubscribeOpenContract(ResponseMessage responseMessage)
        {
            _client.SubscribeOpenContract(responseMessage);
        }
    }
}