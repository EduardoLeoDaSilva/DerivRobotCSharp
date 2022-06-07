using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models.Classes;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Services;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Robots
{
    public abstract class BaseRobot : IRobotOperations
    {
        private ITradeService tradeService;

        protected BaseRobot(ITradeService tradeService)
        {
            this.tradeService = tradeService;
        }



        public List<Quote> Quotes { get; set; }
        public void  GetAmountWithMartingale(OperationInfo operationInfo, decimal martingale, MartingaleType martingaleType)
        {

            if (operationInfo.LastValueLost + operationInfo.LossToRecover <= 0.35M)
            {
                operationInfo.NewAmount = 0;
                return;
            }
        
            
            if (martingaleType == MartingaleType.Normal)
            {
                var newAmount = ((operationInfo.LastValueLost + operationInfo.LossToRecover) * martingale) + operationInfo.LastValueLost;
                operationInfo.NewAmount = newAmount;
            }
            else if(martingaleType == MartingaleType.Recover)
            {
                var newAmount = (operationInfo.LastValueLost + operationInfo.LossToRecover)+ (decimal)0.10;
                operationInfo.NewAmount = newAmount;
            }
            else
            {
                operationInfo.NewAmount = 0;
            }
        }

        public virtual Transaction GetTransactionFromCurrentOperationMarket(string market, ResponseMessage responseMessage)
        {
            if (responseMessage.Transaction.Symbol == market)
            {
                return responseMessage.Transaction;
            }

            return null;
        }


        public virtual void VerifyAndBuy(ResponseMessage message)
        {

            throw new NotImplementedException();
        }

        public bool IsToStopOperation()
        {
            var stopWin = tradeService.RobotConfigutarion.StopWin;
            var stopLoss = tradeService.RobotConfigutarion.StopLoss;
            var currentBalanceOperation = tradeService.currentOperation.CurrentOperationBalance;
            var nextStake = tradeService.currentOperation.NewAmount;


            if (currentBalanceOperation >= stopWin)
            {
                tradeService.Log.Log = "Meta Batida, parando robô";
                this.StopOperation();
                return true;
            }

            if (currentBalanceOperation < (stopLoss * -1))
            {
                tradeService.Log.Log = "Stop Loss, parando robô";
                this.StopOperation();
                return true;

            }

            // if (nextStake >= stopLoss && !tradeService.IsOperating)
            // {
            //     tradeService.Log.Log = "Stop Loss, parando robô";
            //     this.StopOperation();
            //     return true;
            //
            // }

            return false;

        }

        public virtual void StopOperation()
        {
            tradeService.StopOperation();
        }

        public void UpdateOperationInfo(ResponseMessage message, ITradeService tradeService)
        {
            tradeService.UpdateOperationInfoValues(message);
        }

        public virtual void FillQuotesWithHistoricalData(ResponseMessage message)
        {
            this.Quotes = new List<Quote>();

            foreach (var candle in message.Candles)
            {
                var quote = BuildQuoteModel(candle);
                this.Quotes.Add(quote);
            }
        }
    
        public virtual Quote BuildQuoteModel(ResponseMessage message)
        {
            if (message.MsgType == MsgType.Tick)
            {
                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(message.Tick.Epoch).ToLocalTime();

                var Quote = new Quote()
                {
                    Close = message.Tick.Quote,
                    Date = dt
                };
                return Quote;
            }else if (message.MsgType == MsgType.Ohlc)
            {
                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(message.Ohlc.Epoch).ToLocalTime();

                var Quote = new Quote()
                {
                    Close = message.Ohlc.Close,
                    High = message.Ohlc.High,
                    Low = message.Ohlc.Low,
                    Open = message.Ohlc.Open,
                    Date = dt
                };
                return Quote;
            }

            return null;
        }
    
    
        public virtual Candle BuildCandleModel(ResponseMessage message)
        {
            if (message.MsgType == MsgType.Tick)
            {
                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(message.Tick.Epoch).ToLocalTime();

                var candle = new Candle()
                {
                    Close = message.Tick.Quote,
                    Date = dt
                };
                return candle;
            }else if (message.MsgType == MsgType.Ohlc)
            {
                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(message.Ohlc.Epoch).ToLocalTime();

                var candle = new Candle()
                {
                    Close = message.Ohlc.Close,
                    High = message.Ohlc.High,
                    Low = message.Ohlc.Low,
                    Open = message.Ohlc.Open,
                    Date = dt
                };
                return candle;
            }

            return null;
        }
    
        public virtual Quote BuildQuoteModel(CandleResponse candle)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(candle.Epoch).ToLocalTime();

            var Quote = new Quote()
            {
                Close = candle.Close,
                High = candle.High,
                Low = candle.Low,
                Open = candle.Open,
                Date = dt
            };
            return Quote;
        }
    

    }
}