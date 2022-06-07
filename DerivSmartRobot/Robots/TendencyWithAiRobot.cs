using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Models.View;
using DerivSmartRobot.Services;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Robots
{
    public class TendencyWithAi : BaseRobot, IRobotOperations, ITendencyWithAiRobot
    {
        private readonly ITradeService _tradeService;
        private string ZigZagDirection = "";
        private List<decimal> zigZagList;
        private List<string> points;
        private DateTime LastFractal;
        public DateTime? LastHistoricalDateDeadLine { get; set; }
        private readonly AIService _aiService;
        private readonly IClientDeriv _client;


        public TendencyWithAi(ITradeService tradeService, AIService aiService, IClientDeriv client) : base(tradeService)
        {
            _tradeService = tradeService;
            _aiService = aiService;
            _client = client;
            zigZagList = new List<decimal>();
            points = new List<string>();
        }

        public override async void VerifyAndBuy(ResponseMessage message)
        {



            var quote = this.BuildQuoteModel(message);

            if (Quotes == null)
                Quotes = _tradeService.QuotesCached;

            Quotes.Add(quote);

            IEnumerable<Quote> minuteBarQuotes =
                Quotes.Aggregate(TimeSpan.FromMinutes(2));


            var zigZag = minuteBarQuotes.GetZigZag(EndType.HighLow, percentChange: 10).Where(x => x.ZigZag != null);
            var zigZa2g = minuteBarQuotes.GetZigZag(EndType.HighLow, percentChange: 0.1M);
            var ema = minuteBarQuotes.GetWma(14);
            var sar = minuteBarQuotes.GetParabolicSar();




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



            var predictionsTrainData = candles.Select(x => new PredictionCandleDud
            {
                Close = (float)x.Close,
                Low = (float)x.Low,
                Date = x.Date.ToString("t"),
                High = (float)x.High,
                Open = (float)x.Open,
                Volume = (float)x.Volume
            });

            var predictionsTrainData2 = candles.Select(x => new PredictionCandleDud2
            {
                Close = (float)x.Close,
                Low = (float)x.Low,
                Date = x.Date.ToString("t"),
                High = (float)x.High,
                Open = (float)x.Open
            });



            if (LastHistoricalDateDeadLine == null)
            {
                LastHistoricalDateDeadLine = DateTime.Now.AddMinutes(5); ;
                _aiService.Load(predictionsTrainData.ToList());
            }



            var prediction = _aiService.TestSinglePrediction(_aiService.model, predictionsTrainData.Last());
            //var prediction = _aiService.Train2(predictionsTrainData2.ToList()).First();



            _tradeService.Log = new LogView { Date = new DateTime(), Log = "Analisando cotas ..." };


            _tradeService.Log.Log += $";Predição2; -";

            _tradeService.Log.Log += $";{string.Join(';', prediction)}";




            _tradeService.Log.Log += $";DeadLine quotes: {LastHistoricalDateDeadLine.Value.ToString("g")}";


            _tradeService.Log.Log += $";Candle de {predictionsTrainData.Last().Date}";
            _tradeService.Log.Log += $";Predição: {prediction}";


            _tradeService.Log.Log += $";Zig {zigZa2g.Last().Date} {zigZa2g.Last().PointType}";
            if (prediction > (float) candles.Last().Close && DateTime.Now.Second > 30 &&
                Quotes.Last().Close < Quotes.TakeLast(2).First().Close &&
                (prediction - (float) Quotes.Last().Close) >= 0.5 && ema.Last().Wma < candles.Last().Low) 
            {
                this.MakeAProposal(ContractType.CALL, 30, "s");

            }
            else if (prediction < (float)candles.Last().Close &&
                     DateTime.Now.Second > 30 && Quotes.Last().Close > Quotes.TakeLast(2).First().Close &&
                     ((float)Quotes.Last().Close - prediction) >= 0.5 && ema.Last().Wma > candles.Last().High)
            {
                this.MakeAProposal(ContractType.PUT, 30, "s");

            }


            //if (DateTime.Now > LastHistoricalDateDeadLine)
            //{
            //    _client.Forget(_tradeService.CandleSubscriptionId.ToString());
            //    _client.Forget(_tradeService.CandleSubscriptionId.ToString());
            //    _tradeService.Log.Log += $";Nova leva de cotas";

            //    await Task.Delay(2000);
            //    _tradeService.CandleSubscriptionId = Guid.Empty;
            //    Quotes.Clear();
            //    _client.GetCandlesStream(_tradeService.RobotConfigutarion.Market, 60, true);
            //    LastHistoricalDateDeadLine = null;
            //}


            //var last3ZigZags = zigZa2g.TakeLast(3).ToArray();
            //if (!string.IsNullOrEmpty(zigZag.Last().PointType))
            //{
            //    points.Add(zigZag.Last().PointType);
            //}

            //if (
            //    zigZa2g.Last().RetraceLow != null)
            //{
            //    _tradeService.Log.Log += $";ZigZag direção: UP {zigZag.Last().ZigZag}";
            //    ZigZagDirection = "up";
            //    _tradeService.Log.Log += $";Data ZigZag {zigZag.Last().Date}";
            //}
            //else if (
            //    zigZa2g.Last().RetraceHigh != null)
            //{
            //    ZigZagDirection = "down";

            //    _tradeService.Log.Log += $";ZigZag direção: DOWN {zigZag.Last().ZigZag}";
            //    _tradeService.Log.Log += $";Data ZigZag {zigZag.Last().Date}";
            //}
            //else
            //{
            //    ZigZagDirection = "";

            //    _tradeService.Log.Log += $";ZigZag direção: Possível reversão {zigZag.Last().ZigZag}";
            //    _tradeService.Log.Log += $";Data ZigZag {zigZag.Last().Date}";
            //}


            //if (ZigZagDirection == "up")
            //{
            //    if (candles.TakeLast(2).First().IsBullish && candles.Last().IsBearish &&
            //        candles.Last().BodyPct > 0.20  && Quotes.Last().Close > Quotes.TakeLast(2).First().Close && ema.Last().Wma < candles.Last().Low) 
            //    {
            //        _tradeService.Log.Log += $";Realizando compra UP";
            //        this.MakeAProposal(ContractType.CALL, 1, "m");
            //    }
            //}

            //if ( ZigZagDirection == $"down")
            //{
            //    if (candles.TakeLast(2).First().IsBearish && candles.Last().IsBullish &&
            //        candles.Last().BodyPct > 0.20 && Quotes.Last().Close < Quotes.TakeLast(2).First().Close && ema.Last().Wma > candles.Last().High)
            //    {
            //        _tradeService.Log.Log += $";Realizando compra DOWN";
            //        this.MakeAProposal(ContractType.PUT, 1, "m");
            //    }
            //}
        }

        private void MakeAProposal(ContractType contract, int duration, string durationUnit)
        {
            _tradeService.MakeAProposal(contract, duration, durationUnit);
        }
    }
}

public interface ITendencyWithAiRobot : IRobotOperations
{
}