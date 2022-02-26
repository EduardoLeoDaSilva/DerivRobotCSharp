using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Services;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Robots;

public interface IMacdRobot : IRobotOperations
{
}

public class MacdRobot :BaseRobot, IRobotOperations, IMacdRobot
{
    private readonly ITradeService _tradeService;
    public decimal? LastHistogramValue { get; set; }

    public MacdRobot(ITradeService tradeService)
    {
        _tradeService = tradeService;
    }
    public override void VerifyAndBuy(ResponseMessage message)
    {
        var quote  = this.BuildQuoteModel(message);
        Quotes.Add(quote);
        
        IEnumerable<Quote> minuteBarQuotes =
            Quotes.Aggregate(PeriodSize.OneMinute);
        
        var macdResults = minuteBarQuotes.GetMacd();
        

        if (macdResults.TakeLast(5).Any(x => x.Histogram < 0) && macdResults.Last().Histogram > (decimal?) 0.1)
        {
            Console.WriteLine("MACD");

            Console.WriteLine("BUY");
            this.MakeAProposal(ContractType.CALL, 2, "m");
        }else if (macdResults.TakeLast(5).Any(x => x.Histogram >0) && macdResults.Last().Histogram < (decimal?) -0.1)
        {
            Console.WriteLine("MACD");

            Console.WriteLine("SELL");
            this.MakeAProposal(ContractType.PUT, 2, "m");

        }
    }

    private void MakeAProposal(ContractType contract, int duration, string durationUnit)
    {
        _tradeService.MakeAProposal(contract, duration, durationUnit);
    }
    
}