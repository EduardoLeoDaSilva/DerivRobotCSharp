using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models.Classes;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Services;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Robots;

public abstract class BaseRobot : IRobotOperations
{
    public List<Quote> Quotes { get; set; }
    public void  GetAmountWithMartingale(OperationInfo operationInfo, decimal martingale, MartingaleType martingaleType)
    {

        if (operationInfo.LastValueLost == 0)
        {
            operationInfo.NewAmount = 0;
            return;
        }
        
        if (martingaleType == MartingaleType.Normal)
        {
            var newAmount = (operationInfo.LastValueLost * martingale) + operationInfo.LastValueLost;
            operationInfo.NewAmount = newAmount;
        }
        else if(martingaleType == MartingaleType.Recover)
        {
            var newAmount = operationInfo.LossToRecover + (decimal)0.10;
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

    public virtual void StopOperation()
    {
        throw new NotImplementedException();
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