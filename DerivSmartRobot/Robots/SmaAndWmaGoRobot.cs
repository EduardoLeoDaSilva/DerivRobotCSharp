using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Services;
using Skender.Stock.Indicators;
namespace DerivSmartRobot.Robots
{
    public class SmaAndWmaGoRobot: BaseRobot, IRobotOperations, ISmaAndWmaGoRobot
    {
        private readonly ITradeService _tradeService;
        private int Counter = 0;
        private string LastIndicatorSign = "";
        public SmaAndWmaGoRobot(ITradeService tradeService) :base(tradeService)
        {
            _tradeService = tradeService;
        }
        public override void VerifyAndBuy(ResponseMessage message)
        {
            var quote  = this.BuildQuoteModel(message);
            Quotes.Add(quote);
        
            IEnumerable<Quote> minuteBarQuotes =
                Quotes.Aggregate(PeriodSize.OneMinute);

            var smaFast = minuteBarQuotes.GetSma(1);
            var smaSlow = minuteBarQuotes.GetSma(34);

            var listDiff = smaFast.Except(smaSlow).Select(x => new Quote{Close = x.Sma ?? 0, Date = x.Date});

            var diffList = listDiff.Select(x => new SmaResult {Date = x.Date, Sma = x.Close});
            var WmaList = listDiff.GetWma(5).Select(x => new SmaResult{Date = x.Date, Sma = x.Wma});

            if ( diffList.ToList().Last().Sma < WmaList.ToList().Last().Sma)
            {
                if (LastIndicatorSign == "" || LastIndicatorSign == "sell")
                {

                 
                    LastIndicatorSign = "sell";
                    Counter += 1;
                    if (Counter > 5)
                    {
                        this.MakeAProposal(ContractType.PUT, 5, "t");
                        LastIndicatorSign = "";
                        Counter = 0;
                    }
                }
                else
                {
                    LastIndicatorSign = "";
                    Counter = 0;
                }

                Console.WriteLine("SELL");
            }else if ( diffList.ToList().Last().Sma > WmaList.ToList().Last().Sma)
            {
                if (LastIndicatorSign == "" || LastIndicatorSign == "buy")
                {
                    LastIndicatorSign = "buy";
                    Counter += 1;
                    if (Counter > 5)
                    {
                        this.MakeAProposal(ContractType.CALL, 5, "t");
                        LastIndicatorSign = "";
                        Counter = 0;
                    }
                }
                else
                {
                    LastIndicatorSign = "";
                    Counter = 0;
                }
                Console.WriteLine("BUY");
            }
         
        }

    
        private void MakeAProposal(ContractType contract, int duration, string durationUnit)
        {
            _tradeService.MakeAProposal(contract, duration, durationUnit);
        }
    
        private List<Quote> DiffCalculate(IEnumerable<SmaResult> smaFast, IEnumerable<SmaResult> smaSlow)
        {
            var listDiff = new List<Quote>();


            var smaResultsFast = smaFast as SmaResult[] ?? smaFast.ToArray();
            var smaResultsSlow = smaSlow as SmaResult[] ?? smaSlow.ToArray();

            for (int i = 0; i < smaResultsFast.Count(); i++)
            {
                var diff = smaResultsSlow[i].Sma == null ? smaResultsFast[i].Sma :  smaResultsFast[i].Sma - smaResultsSlow[i].Sma;
                listDiff.Add(new Quote{Close = diff.Value, Date = smaResultsFast[i].Date});
            }

            return listDiff;
        }
    
    }

    public interface ISmaAndWmaGoRobot : IRobotOperations
    {
    }
}