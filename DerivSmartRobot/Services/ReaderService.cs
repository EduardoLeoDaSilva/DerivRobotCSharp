using System.Runtime.InteropServices;
using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Models.Classes;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Redis;
using DerivSmartRobot.Robots;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using ErrorEventArgs = WebSocketSharp.ErrorEventArgs;
using MessageEventArgs = WebSocketSharp.MessageEventArgs;

namespace DerivSmartRobot.Services
{
    public class ReaderService
    {
        private static ITradeService _tradeService;

        private readonly IClientDeriv _client;

        private readonly ITendencyWithAiRobot _tendencyWithAiRobot;
        private readonly IDigitAiPrediction _digitAiPrediction;
        private readonly IFractalRobot _fractalRobot;
        private readonly IRsiMacdRobot _rsiMacdRobot;

        private readonly ILogger<ReaderService> _logger;
        private bool _alreadySubscribedCandleStream = false;






        public ReaderService(
            ITradeService tradeService,
            ITendencyWithAiRobot tendencyWithAiRobot, IDigitAiPrediction digitAiPrediction, IFractalRobot fractalRobot, ILogger<ReaderService> logger, IClientDeriv client, IRsiMacdRobot rsiMacdRobot)
        {
            _tradeService = tradeService;

            _tendencyWithAiRobot = tendencyWithAiRobot;
            _digitAiPrediction = digitAiPrediction;
            _fractalRobot = fractalRobot;
            _logger = logger;
            _client = client;
            _rsiMacdRobot = rsiMacdRobot;
        }



        public void ReadValueFromDeriv(object? sender, MessageEventArgs e)
        {

            var webSocketReturn = JsonConvert.DeserializeObject<ResponseMessage>(e.Data);
            Console.WriteLine(e.Data);


            _logger.LogInformation(e.Data);
            if (webSocketReturn.Error != null)
            {
                _tradeService.HasOpenContract = false;
                Console.WriteLine($"{webSocketReturn.Error.Message}");

                if (webSocketReturn?.MsgType == MsgType.Proposal_open_contract)
                {
                    _tradeService.SubscribeOpenContract(webSocketReturn);

                }
                return;
            }

            switch (webSocketReturn?.MsgType)
            {
                case MsgType.Tick:
                    SendToRobot(webSocketReturn, CommandsApi.TickStream);
                    break;
                case MsgType.Transaction:
                    SendToRobot(webSocketReturn, CommandsApi.TransactionStream);
                    break;
                case MsgType.Buy:
                    SendToRobot(webSocketReturn, CommandsApi.Buy);
                    break;
                case MsgType.Proposal:
                    SendToRobot(webSocketReturn, CommandsApi.Proposal);
                    break;
                case MsgType.Proposal_open_contract:
                    SendToRobot(webSocketReturn, CommandsApi.OpenContract);
                    break;
                case MsgType.Ohlc:
                    SendToRobot(webSocketReturn, CommandsApi.OlhcStream);
                    break;
                case MsgType.Candles:
                    SendToRobot(webSocketReturn, CommandsApi.Candles);
                    break;
                case MsgType.Balance:
                    if (!_alreadySubscribedCandleStream)
                    {
                        _client.GetCandlesStream(_tradeService.RobotConfigutarion.Market, 60, true); //todo mudar dpois
                        _alreadySubscribedCandleStream = true;
                    }
                    SendToRobot(webSocketReturn, CommandsApi.Balance);
                    break;
                case MsgType.Forget:
                    _tradeService.Log.Log += $";{webSocketReturn.Forget}";
                    break;
                case MsgType.Authorize:
                    _client.GetBalanceStream();
                    break;
            }
        }

        public void SendToRobot(ResponseMessage responseMessage, CommandsApi commandsApi)
        {

            if (CommandsApi.Balance == commandsApi)
            {
                _tradeService.UpdateBalance(responseMessage);
                return;
            }

            switch (_tradeService.RobotConfigutarion.RobotType)
            {
                //case RobotType.TendencyWithAiRobot:
                //    switch (commandsApi)
                //    {
                //        case CommandsApi.OlhcStream:
                //            _tradeService.CandleSubscriptionId = responseMessage.Subscription.Id;
                //            _tendencyWithAiRobot.VerifyAndBuy(responseMessage);
                //            break;
                //        case CommandsApi.TransactionStream:
                //            var transaction = _tendencyWithAiRobot.GetTransactionFromCurrentOperationMarket(
                //                _tradeService.RobotConfigutarion.Market,
                //                responseMessage);
                //            if (transaction != null)
                //            {
                //                Console.WriteLine($"Lucro/Perda de: {transaction.Amount}");
                //                _tendencyWithAiRobot.UpdateOperationInfo(responseMessage, _tradeService);
                //            }
                //            _tendencyWithAiRobot.GetAmountWithMartingale(_tradeService.currentOperation,
                //                _tradeService.RobotConfigutarion.MartingaleValue,
                //                _tradeService.RobotConfigutarion.MartigaleType);

                //            break;
                //        case CommandsApi.Buy:
                //            Console.WriteLine($"Realizando aporte de {responseMessage.Buy.buy_price}");
                //            break;
                //        case CommandsApi.Proposal:
                //            _tradeService.BuyAContract(responseMessage.Proposal);
                //            break;
                //        case CommandsApi.Candles:
                //            _tendencyWithAiRobot.FillQuotesWithHistoricalData(responseMessage);
                //            break;
                //    }
                //    break;
                case RobotType.OverOrUnderProbability:
                    switch (commandsApi)
                    {
                        case CommandsApi.OlhcStream:
                            _tradeService.CandleSubscriptionId = responseMessage.Subscription.Id;
                            _digitAiPrediction.VerifyAndBuy(responseMessage);
                            break;
                        case CommandsApi.TransactionStream:
                            var transaction = _digitAiPrediction.GetTransactionFromCurrentOperationMarket(
                                _tradeService.RobotConfigutarion.Market,
                                responseMessage);
                            if (transaction != null)
                            {
                                Console.WriteLine($"Lucro/Perda de: {transaction.Amount}");
                                _digitAiPrediction.UpdateOperationInfo(responseMessage, _tradeService);
                            }
                            _digitAiPrediction.GetAmountWithMartingale(_tradeService.currentOperation,
                                _tradeService.RobotConfigutarion.MartingaleValue,
                                _tradeService.RobotConfigutarion.MartigaleType);

                            break;
                        case CommandsApi.OpenContract:

                            _digitAiPrediction.UpdateOperationInfo(responseMessage, _tradeService);

                            _digitAiPrediction.GetAmountWithMartingale(_tradeService.currentOperation,
                                _tradeService.RobotConfigutarion.MartingaleValue,
                                _tradeService.RobotConfigutarion.MartigaleType);

                            break;

                        case CommandsApi.Buy:
                            _tradeService.SubscribeOpenContract(responseMessage);
                            break;
                        case CommandsApi.Proposal:
                            _tradeService.BuyAContract(responseMessage.Proposal);
                            break;
                        case CommandsApi.Candles:
                            _digitAiPrediction.FillQuotesWithHistoricalData(responseMessage);
                            break;
                    }
                    break;
                case RobotType.FractalWithTendency:
                    switch (commandsApi)
                    {
                        case CommandsApi.OlhcStream:
                            _tradeService.CandleSubscriptionId = responseMessage.Subscription.Id;
                            _fractalRobot.VerifyAndBuy(responseMessage);
                            break;
                        case CommandsApi.TransactionStream:
                            var transaction = _fractalRobot.GetTransactionFromCurrentOperationMarket(
                                _tradeService.RobotConfigutarion.Market,
                                responseMessage);
                            if (transaction != null)
                            {
                                Console.WriteLine($"Lucro/Perda de: {transaction.Amount}");
                                _fractalRobot.UpdateOperationInfo(responseMessage, _tradeService);
                            }
                            _fractalRobot.GetAmountWithMartingale(_tradeService.currentOperation,
                                _tradeService.RobotConfigutarion.MartingaleValue,
                                _tradeService.RobotConfigutarion.MartigaleType);

                            break;

                        case CommandsApi.OpenContract:

                                _fractalRobot.UpdateOperationInfo(responseMessage, _tradeService);
                            
                            _fractalRobot.GetAmountWithMartingale(_tradeService.currentOperation,
                                _tradeService.RobotConfigutarion.MartingaleValue,
                                _tradeService.RobotConfigutarion.MartigaleType);

                            break;

                        case CommandsApi.Buy:
                            _tradeService.SubscribeOpenContract(responseMessage);
                            break;
                        case CommandsApi.Proposal:
                            _tradeService.BuyAContract(responseMessage.Proposal);
                            break;
                        case CommandsApi.Candles:
                            _fractalRobot.FillQuotesWithHistoricalData(responseMessage);
                            break;
                    }
                    break;
                case RobotType.RsiWithMacd:
                    switch (commandsApi)
                    {
                        case CommandsApi.OlhcStream:
                            _tradeService.CandleSubscriptionId = responseMessage.Subscription.Id;
                            _rsiMacdRobot.VerifyAndBuy(responseMessage);
                            break;
                        case CommandsApi.TransactionStream:
                            var transaction = _rsiMacdRobot.GetTransactionFromCurrentOperationMarket(
                                _tradeService.RobotConfigutarion.Market,
                                responseMessage);
                            if (transaction != null)
                            {
                                Console.WriteLine($"Lucro/Perda de: {transaction.Amount}");
                                _rsiMacdRobot.UpdateOperationInfo(responseMessage, _tradeService);
                            }
                            _rsiMacdRobot.GetAmountWithMartingale(_tradeService.currentOperation,
                                _tradeService.RobotConfigutarion.MartingaleValue,
                                _tradeService.RobotConfigutarion.MartigaleType);

                            break;

                        case CommandsApi.OpenContract:

                            _rsiMacdRobot.UpdateOperationInfo(responseMessage, _tradeService);

                            _rsiMacdRobot.GetAmountWithMartingale(_tradeService.currentOperation,
                                _tradeService.RobotConfigutarion.MartingaleValue,
                                _tradeService.RobotConfigutarion.MartigaleType);

                            break;

                        case CommandsApi.Buy:
                            _tradeService.SubscribeOpenContract(responseMessage);
                            break;
                        case CommandsApi.Proposal:
                            _tradeService.BuyAContract(responseMessage.Proposal);
                            break;
                        case CommandsApi.Candles:
                            _rsiMacdRobot.FillQuotesWithHistoricalData(responseMessage);
                            break;
                    }
                    break;
            }
        }

        public static void ReadValueErrorEvent(object? sender, ErrorEventArgs e)
        {
            Console.WriteLine("Erro retornado do websocket");
        }


    }
}

