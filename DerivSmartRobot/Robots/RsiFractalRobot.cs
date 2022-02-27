using System.Globalization;
using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Services;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Robots;

public class RsiFractalRobot : BaseRobot, IRobotOperations, IRsiFractalRobot
{
    public DateTime LastFractalBuyDate { get; set; }

    private readonly ITradeService _tradeService;

    public RsiFractalRobot(ITradeService tradeService)
    {
        _tradeService = tradeService;
    }

    public override void VerifyAndBuy(ResponseMessage message)
    {
        var quote = this.BuildQuoteModel(message);
        Quotes.Add(quote);

        IEnumerable<Quote> minuteBarQuotes =
            Quotes.Aggregate(TimeSpan.FromMinutes(2));

        var rsi = minuteBarQuotes.GetRsi().Last().Rsi;

        var fractalResults = minuteBarQuotes.GetFractal(3).Where(x => x.FractalBear != null || x.FractalBull != null);
        var sma5 = minuteBarQuotes.GetSma(5);
        var sma2 = minuteBarQuotes.GetSma(2);
        var sma100 = minuteBarQuotes.GetSma(100);



        var fractal = fractalResults.Last();

        var candles = Quotes
            .OrderBy(x => x.Date)
            .GroupBy(x => x.Date.ToString("g"))
            .Select(x => new CandleDud()
            {
                Date = DateTime.Parse(x.Key),
                Open = x.First().Open,
                High = x.Max(t => t.High),
                Low = x.Min(t => t.Low),
                Close = x.Last().Close,
                Volume = x.Sum(t => t.Volume)
            });


        if ((quote.Date - fractal.Date).TotalMinutes < 5
            && fractal.FractalBear != null
            && LastFractalBuyDate != fractal.Date
            && sma100.Last().Sma < quote.Close
            && sma5.TakeLast(2).First().Sma >= sma2.TakeLast(2).First().Sma
            && sma2.Last().Sma > sma5.Last().Sma)
        {
            LastFractalBuyDate = fractal.Date;
            Console.WriteLine("Fractal");

            Console.WriteLine("Comprando em CALL");
            this.MakeAProposal(ContractType.PUT, 1, "m");
        }
        else if ((quote.Date - fractal.Date).TotalMinutes < 5
                 && fractal.FractalBull != null
                 && LastFractalBuyDate != fractal.Date
                 && sma100.Last().Sma > quote.Close
                 && sma5.TakeLast(2).First().Sma <= sma2.TakeLast(2).First().Sma
                 && sma2.Last().Sma < sma5.Last().Sma)
        {
            Console.WriteLine("Fractal");

            LastFractalBuyDate = fractal.Date;
            Console.WriteLine("Comprando em PUT");
            this.MakeAProposal(ContractType.CALL, 1, "m");
        }
    }

    public override void StopOperation()
    {
        base.StopOperation();
    }

    private void MakeAProposal(ContractType contract, int duration, string durationUnit)
    {
        _tradeService.MakeAProposal(contract, duration, durationUnit);
    }
}

public interface IRsiFractalRobot : IRobotOperations
{
}