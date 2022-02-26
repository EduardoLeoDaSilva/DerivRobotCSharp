using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Models.Classes;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Services;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Interfaces.Services;

public interface IRobotOperations
{
    void VerifyAndBuy(ResponseMessage message);
    void StopOperation();

    void GetAmountWithMartingale(OperationInfo operationInfo, decimal martingale, MartingaleType martingaleType);

    Transaction GetTransactionFromCurrentOperationMarket(string market, ResponseMessage responseMessage);
    void UpdateOperationInfo(ResponseMessage message, ITradeService tradeService);

     Quote BuildQuoteModel(CandleResponse candle);
     Quote BuildQuoteModel(ResponseMessage message);
     void FillQuotesWithHistoricalData(ResponseMessage message);
}