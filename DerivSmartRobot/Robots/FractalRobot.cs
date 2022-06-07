using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Models.View;
using DerivSmartRobot.Services;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Robots { 

public class FractalRobot : BaseRobot, IRobotOperations, IFractalRobot
{
    private readonly ITradeService _tradeService;
    public DateTime LastFractal { get; set; }

    public FractalRobot(ITradeService tradeService) : base(tradeService)
    {
        _tradeService = tradeService;
    }

    public override void VerifyAndBuy(ResponseMessage message)
    {
        var quote = this.BuildQuoteModel(message);
        Quotes.Add(quote);
        this._tradeService.Log = this._tradeService.Log = new LogView { Date = DateTime.Now, Log = "Verificando cotas" };

        IEnumerable<Quote> minuteBarQuotes =
            Quotes.Aggregate(TimeSpan.FromMinutes(1));




        var candles = minuteBarQuotes
            .OrderBy(x => x.Date)
            .Select(x => new CandleDud()
            {
                Date = x.Date,
                Open = x.Open,
                High = x.High,
                Low = x.Low,
                Close = x.Close,
                Volume = x.Volume
            });

        var fractal = minuteBarQuotes.GetFractal();
        var wma = minuteBarQuotes.GetWma(14);
        var sma = minuteBarQuotes.GetSma(14);
        var ema = minuteBarQuotes.GetEma(14);
        var alligator = minuteBarQuotes.GetAlligator();
        // var sar = minuteBarQuotes.GetParabolicSar();

        var fractalList = fractal.Where(x => x.FractalBear != null || x.FractalBull != null);

        this._tradeService.Log.Log += $";Data Último fractal: {fractalList.Last().Date.ToString("g") }";
        if (fractalList.Last().FractalBear != null)
            this._tradeService.Log.Log += $";Sinal fractal: VENDA";
        else
            this._tradeService.Log.Log += $";Sinal fractal: COMPRA";

        if (wma.Last().Wma < minuteBarQuotes.Last().Close &&
            sma.Last().Sma < minuteBarQuotes.Last().Close &&
            ema.Last().Ema < minuteBarQuotes.Last().Close)
        {
            this._tradeService.Log.Log += $";Sinal de tendência: COMPRA";
        }

        if (wma.Last().Wma > minuteBarQuotes.Last().Close &&
            sma.Last().Sma > minuteBarQuotes.Last().Close &&
            ema.Last().Ema > minuteBarQuotes.Last().Close)
        {
            this._tradeService.Log.Log += $";Sinal de tendência: VENDA";
        }

        var last2Alligators = alligator.TakeLast(2);

        if (
            last2Alligators.First().Lips > last2Alligators.First().Teeth && last2Alligators.Last().Lips < last2Alligators.Last().Teeth
            && minuteBarQuotes.Last().Close < last2Alligators.Last().Teeth)
        {
            this.MakeAProposal(ContractType.PUT, 1, "m", null);
            LastFractal = fractalList.Last().Date;
        }

        if (last2Alligators.First().Lips < last2Alligators.First().Teeth && last2Alligators.Last().Lips > last2Alligators.Last().Teeth
                                                                         && minuteBarQuotes.Last().Close < last2Alligators.Last().Teeth
           )
        {
            this.MakeAProposal(ContractType.CALL, 1, "m", null);
            LastFractal = fractalList.Last().Date;
        }
    }

    public void MakeAProposal(ContractType contract, int duration, string durationUnit, string? barrier)
    {
        _tradeService.MakeAProposal(contract, duration, durationUnit, barrier);
    }
}

public interface IFractalRobot : IRobotOperations
{
}
}