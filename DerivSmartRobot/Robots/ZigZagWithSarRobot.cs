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
        private string ZigZagDirection = "";
        private List<decimal> zigZagList;
        private List<string> points;
        private DateTime LastFractal;

        public ZigZagWithSarRobot(ITradeService tradeService) : base(tradeService)
        {
            _tradeService = tradeService;
            zigZagList = new List<decimal>();
            points = new List<string>();
        }

        public override void VerifyAndBuy(ResponseMessage message)
        {
            var quote = this.BuildQuoteModel(message);

            if (Quotes == null)
                Quotes = _tradeService.QuotesCached;

            Quotes.Add(quote);

            IEnumerable<Quote> minuteBarQuotes =
                Quotes.Aggregate(TimeSpan.FromMinutes(2));


            var zigZag = minuteBarQuotes.GetZigZag(EndType.HighLow, percentChange: 10).Where(x => x.ZigZag != null);
            var fractalResults =
                minuteBarQuotes.GetFractal(2).Where(x => x.FractalBear != null || x.FractalBull != null);
            var zigZa2g = minuteBarQuotes.GetZigZag(EndType.HighLow, percentChange: 0.1M);


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


            _tradeService.Log = new LogView {Date = new DateTime(), Log = "Analisando cotas ..."};

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


            var last3ZigZags = zigZa2g.TakeLast(3).ToArray();
            if (!string.IsNullOrEmpty(zigZag.Last().PointType))
            {
                points.Add(zigZag.Last().PointType);
            }

            if (
                zigZa2g.Last().RetraceLow != null)
            {
                _tradeService.Log.Log += $";ZigZag direção: UP {zigZag.Last().ZigZag}";
                ZigZagDirection = "up";
                _tradeService.Log.Log += $";Data ZigZag {zigZag.Last().Date}";
            }
            else if (
                zigZa2g.Last().RetraceHigh != null)
            {
                ZigZagDirection = "down";

                _tradeService.Log.Log += $";ZigZag direção: DOWN {zigZag.Last().ZigZag}";
                _tradeService.Log.Log += $";Data ZigZag {zigZag.Last().Date}";
            }
            else
            {
                ZigZagDirection = "";

                _tradeService.Log.Log += $";ZigZag direção: Possível reversão {zigZag.Last().ZigZag}";
                _tradeService.Log.Log += $";Data ZigZag {zigZag.Last().Date}";
            }


            if (fractalResults.Last().FractalBull != null && ZigZagDirection == "up" &&
                LastFractal != fractalResults.Last().Date)
            {
                if (candles.TakeLast(2).First().IsBullish)
                {
                    _tradeService.Log.Log += $";Realizando compra UP";
                    this.MakeAProposal(ContractType.CALL, 2, "m");
                    LastFractal = fractalResults.Last().Date;
                }
            }

            if (fractalResults.Last().FractalBear != null && ZigZagDirection == $"down" &&
                LastFractal != fractalResults.Last().Date)
            {
                if (candles.TakeLast(2).First().IsBearish)
                {
                    _tradeService.Log.Log += $";Realizando compra DOWN";
                    this.MakeAProposal(ContractType.PUT, 2, "m");
                    LastFractal = fractalResults.Last().Date;
                }
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