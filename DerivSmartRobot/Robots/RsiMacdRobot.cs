using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Models.View;
using DerivSmartRobot.Services;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Robots
{
    public interface IRsiMacdRobot : IRobotOperations
    {
    }

    public class RsiMacdRobot : BaseRobot, IRobotOperations, IRsiMacdRobot
    {

        public decimal CurrentRsi { get; set; }
        public decimal LastRsi { get; set; }

        public int QuantTime { get; set; } = 0;
        public decimal? LastHistogramValue { get; set; }

        public string RsiAction { get; set; }

        private readonly ITradeService _tradeService;
        public RsiMacdRobot(ITradeService tradeService) :base(tradeService)
        {
            _tradeService = tradeService;
        }

        public override void VerifyAndBuy(ResponseMessage message)
        {
            var quote  = this.BuildQuoteModel(message);
            Quotes.Add(quote);
        
            IEnumerable<Quote> minuteBarQuotes =
                Quotes.Aggregate(PeriodSize.OneMinute);
        
            var rsi = minuteBarQuotes.GetRsi().Last().Rsi;

            _tradeService.Log = new LogView{Date = DateTime.Now, Log = "Realizando análise do RSI e MACD"};

            if (rsi <= 30)
            {
                RsiAction = "buy";
                _tradeService.Log = new LogView { Date = DateTime.Now, Log = "RSI CALL" };

            }
            else if (rsi >= 70)
            {
                RsiAction = "sell";
                _tradeService.Log = new LogView { Date = DateTime.Now, Log = "RSI PUT" };

            }

            var macdResults = minuteBarQuotes.GetMacd();
        

            if (macdResults.TakeLast(10).Any(x => x.Histogram < 0) && macdResults.Last().Histogram > (decimal?) 0 && RsiAction == "buy")
            {
                _tradeService.Log = new LogView { Date = DateTime.Now, Log = "MACD CALL" };

                RsiAction = "";
                this.MakeAProposal(ContractType.CALL, 80, "s");
            }else if (macdResults.TakeLast(10).Any(x => x.Histogram > 0) && macdResults.Last().Histogram < (decimal?) 0 && RsiAction == "sell")
            {
                _tradeService.Log = new LogView { Date = DateTime.Now, Log = "MACD PUT" };

                RsiAction = "";
                this.MakeAProposal(ContractType.PUT, 80, "s");

            }
            LastHistogramValue = macdResults.Last().Histogram;
        }

        private void MakeAProposal(ContractType contract, int duration, string durationUnit)
        {
            _tradeService.MakeAProposal(contract, duration, durationUnit);
        }


    
    }
}