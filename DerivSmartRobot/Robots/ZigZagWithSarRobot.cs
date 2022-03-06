using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Models.View;
using DerivSmartRobot.Services;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Robots
{
    public class ZigZagWithSarRobot : BaseRobot, IRobotOperations, IZigZagWithSarRobot
    {
        private readonly ITradeService _tradeService;
        public ZigZagWithSarRobot(ITradeService tradeService) : base(tradeService)
        {
            _tradeService = tradeService;
        }

        public override void VerifyAndBuy(ResponseMessage message)
        {

            var quote = this.BuildQuoteModel(message);

            if (Quotes == null)
                Quotes = _tradeService.QuotesCached;

            Quotes.Add(quote);

            IEnumerable<Quote> minuteBarQuotes =
                Quotes.Aggregate(TimeSpan.FromMinutes(2));

            var zigZag = minuteBarQuotes.GetZigZag(EndType.HighLow, Decimal.Parse("0,1")).Where(x => !string.IsNullOrEmpty(x.PointType));
            var fractalResults = minuteBarQuotes.GetFractal(2).Where(x => x.FractalBear != null || x.FractalBull != null);
            var zigZa2g = minuteBarQuotes.GetZigZag(EndType.Close, Decimal.Parse("0,1")).Where(x => !string.IsNullOrEmpty(x.PointType));



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


            _tradeService.Log = new LogView { Date = new DateTime(), Log = "Obtendo cotas ..." };


            if (fractalResults.Last().FractalBear != null)
            {
                _tradeService.Log.Log += ";Sinal Fractal: DOWN ";
                _tradeService.Log.Log += $";Data Fractal {fractalResults.Last().Date}";

            }
            else if (fractalResults.Last().FractalBull != null)
            {
                _tradeService.Log.Log += ";Sinal Fractal: UP ";
                _tradeService.Log.Log += $";Data Fractal {fractalResults.Last().Date}";

            }

            _tradeService.Log.Log += $";Zig {zigZa2g.Last().Date} {zigZa2g.Last().PointType}";


            if (zigZag.Last().PointType == "H")
            {
                _tradeService.Log.Log += ";ZigZag direção: DOWN";
                _tradeService.Log.Log += $";Data ZigZag {zigZag.Last().Date}";


            }
            else if (zigZag.Last().PointType == "L")
            {
                _tradeService.Log.Log += ";ZigZag direção: UP";
                _tradeService.Log.Log += $";Data ZigZag {zigZag.Last().Date}";


            }


            if (fractalResults.Last().FractalBull != null && zigZag.Last().PointType == "L")
            {
                _tradeService.Log.Log += ";Realizando compra";
                this.MakeAProposal(ContractType.CALL, 2, "m");
            }

            if (fractalResults.Last().FractalBear != null && zigZag.Last().PointType == "H")
            {
                _tradeService.Log.Log += ";Realizando compra";
                this.MakeAProposal(ContractType.PUT, 2, "m");
            }
        }

        private void MakeAProposal(ContractType contract, int duration, string durationUnit)
        {
            _tradeService.MakeAProposal(contract, duration, durationUnit);
        }
    }
}

public interface IZigZagWithSarRobot : IRobotOperations
{
}
