using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Models.View;
using DerivSmartRobot.Services;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Robots
{
    public class RsiStockHigherAndLowerRobot : BaseRobot, IRobotOperations, IRsiStockHigherAndLowerRobot
    {
        private readonly ITradeService _tradeService;
        //logig attrs
        public int QuantCrossLine { get; set; } = 0;

        public DateTime? BuyDeadLine { get; set; } = null;

        public string ActionStockRsi { get; set; } = "";

        public string ActionParabolicSar { get; set; } = "";
    
    
        public RsiStockHigherAndLowerRobot(ITradeService tradeService) :base(tradeService)
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
                Quotes.Aggregate(TimeSpan.FromMinutes(1));

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

            var rsiList = minuteBarQuotes.GetStochRsi(14, 14, 3, 1);
            var parabolicSarList = minuteBarQuotes.GetParabolicSar();


            var lastStockRsi = rsiList.Last();
            var lastPriorStockRsi = rsiList.TakeLast(2).First();



        
            if (lastPriorStockRsi.StochRsi <= 10
                && lastPriorStockRsi.StochRsi < lastPriorStockRsi.Signal
                && lastStockRsi.StochRsi >= lastStockRsi.Signal)
            {
                _tradeService.Log = new LogView {Date = DateTime.Now, Log = "Análise do StockRsi: CALL"};
                ActionStockRsi = "buy";
            }

            // check for SHORT event
            // condition: Stoch RSI was >= 80 and Stoch RSI crosses under Signal
            if (lastPriorStockRsi.StochRsi >= 90
                && lastPriorStockRsi.StochRsi > lastPriorStockRsi.Signal
                && lastStockRsi.StochRsi <= lastStockRsi.Signal)
            {
                _tradeService.Log = new LogView { Date = DateTime.Now, Log = "Análise do StockRsi: PUT" };
                ActionStockRsi = "sell";
            }

            if (parabolicSarList.Last().Sar > candles.Last().Close &&
                parabolicSarList.Last().Sar > candles.Last().High &&
                parabolicSarList.Last().Sar > candles.Last().Low)
            {
                _tradeService.Log = new LogView { Date = DateTime.Now, Log = "Análise do ParabolicSar: PUT" };
                ActionParabolicSar = "sell";

            }

            if (parabolicSarList.Last().Sar < candles.Last().Close &&
                parabolicSarList.Last().Sar < candles.Last().High &&
                parabolicSarList.Last().Sar < candles.Last().Low)
            {
                ActionParabolicSar = "buy";
                _tradeService.Log = new LogView { Date = DateTime.Now, Log = "Análise do ParabolicSar: CALL" };


            }


            if (string.IsNullOrEmpty(ActionStockRsi) && BuyDeadLine == null)
            {
                BuyDeadLine = DateTime.Now.AddMinutes(15);
                _tradeService.Log = new LogView { Date = DateTime.Now, Log = $"BuyDeadLine setado para às { BuyDeadLine.Value.Date.ToString("G")}" };

            }

            if (DateTime.Now > BuyDeadLine)
            {
                ActionStockRsi = "";
                BuyDeadLine = null;
                _tradeService.Log = new LogView { Date = DateTime.Now, Log = "Reiniciando análise" };

            }

            if (ActionStockRsi == "buy" && candles.TakeLast(1).First().IsBullish && candles.TakeLast(1).First().BodyPct >0.2 && ActionParabolicSar== "buy")
            {
                if (DateTime.Now <= BuyDeadLine)
                {
                    this.MakeAProposal(ContractType.CALL, 5, "t",  "-0.06");
                    ActionStockRsi = "";
                    ActionParabolicSar = "";
                    BuyDeadLine = null;
                }
                else
                {
                    ActionStockRsi = "";
                    ActionParabolicSar = "";
                    BuyDeadLine = null;
                }
            }

            if (ActionStockRsi == "sell"  && candles.TakeLast(1).First().IsBearish && candles.TakeLast(1).First().BodyPct >0.2 && ActionParabolicSar == "sell")
            {
                if (DateTime.Now <= BuyDeadLine)
                {
                    this.MakeAProposal(ContractType.PUT, 5, "t", "+0.06");
                    ActionStockRsi = "";
                    ActionParabolicSar = "";
                    BuyDeadLine = null;
                }
                else
                {
                    ActionStockRsi = "";
                    ActionParabolicSar = "";
                    BuyDeadLine = null;
                }
            }
        }
    
        public void MakeAProposal(ContractType contract, int duration, string durationUnit, string? barrier)
        {
            _tradeService.MakeAProposal(contract, duration, durationUnit, barrier);
        }
    }

    public interface IRsiStockHigherAndLowerRobot : IRobotOperations
    {
    }
}