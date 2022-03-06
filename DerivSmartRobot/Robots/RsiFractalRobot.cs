using System.Globalization;
using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Models.View;
using DerivSmartRobot.Services;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Robots
{
    public class RsiFractalRobot : BaseRobot, IRobotOperations, IRsiFractalRobot
    {
        public DateTime LastFractalBuyDate { get; set; }

        private readonly ITradeService _tradeService;

        public RsiFractalRobot(ITradeService tradeService) :base(tradeService)
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

            _tradeService.Log = new LogView { Date = DateTime.Now, Log = "Obtendo SMAs"};

            _tradeService.Log.Log += $";SMA 5: {sma5.Last().Sma}";
            _tradeService.Log.Log += $";SMA 2:  {sma2.Last().Sma}" ;
        _tradeService.Log.Log += $";SMA 100:  {sma100.Last().Sma}" ;


        _tradeService.Log.Log += ";Obtendo Fractal";
        _tradeService.Log.Log += $";Último fractal:  ${ (fractalResults.Last().FractalBear != null ? "Ponto mais baixo: " +fractalResults.Last().FractalBear   :  "Ponto mais alto:" + fractalResults.Last().FractalBull)} - Data: {fractalResults.Last().Date.ToString("g")}";



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


            if ((quote.Date - fractal.Date).TotalMinutes < 25
                && fractal.FractalBear != null
                && LastFractalBuyDate != fractal.Date
                && sma100.Last().Sma < quote.Close
                && sma5.TakeLast(2).First().Sma >= sma2.TakeLast(2).First().Sma
                && sma2.Last().Sma > sma5.Last().Sma)
            {
                LastFractalBuyDate = fractal.Date;
                this.MakeAProposal(ContractType.PUT, 1, "m");
            }
            else if ((quote.Date - fractal.Date).TotalMinutes < 25
                     && fractal.FractalBull != null
                     && LastFractalBuyDate != fractal.Date
                     && sma100.Last().Sma > quote.Close
                     && sma5.TakeLast(2).First().Sma <= sma2.TakeLast(2).First().Sma
                     && sma2.Last().Sma < sma5.Last().Sma)
            {
                LastFractalBuyDate = fractal.Date;
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
}