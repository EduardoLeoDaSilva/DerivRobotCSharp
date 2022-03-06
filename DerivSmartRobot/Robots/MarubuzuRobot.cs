using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Services;
using Newtonsoft.Json;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Robots
{
    public class MarubuzuRobot : BaseRobot, IRobotOperations, IMarubuzuRobot
    {
        private readonly ITradeService _tradeService;

        public string Action { get; set; } = "";
        public int QuantConfirmationSginals { get; set; } = 0;

        public string LastSignal { get; set; } = "";

        public decimal? LastCandlePrice { get; set; } = null;

        public MarubuzuRobot(ITradeService tradeService):base(tradeService)
        {
            _tradeService = tradeService;
        }
        public override void VerifyAndBuy(ResponseMessage message)
        {
        
            var quote = this.BuildQuoteModel(message);
            Quotes.Add(quote);
        
            IEnumerable<Quote> minuteBarQuotes =
                Quotes.Aggregate(TimeSpan.FromSeconds(5));

            var emaResults = minuteBarQuotes.GetEma(100);

            var candleResults = minuteBarQuotes.GetMarubozu();

            var stochRsi = minuteBarQuotes.GetRsi();

            var ema = minuteBarQuotes.GetEma(100);

            //if (string.IsNullOrEmpty(Action) && stochRsi.Last().Rsi >= 70)
            //{
            //    Action = "sell";
            //}

            //if (string.IsNullOrEmpty(Action) && stochRsi.Last().Rsi <= 30)
            //{
            //    Action = "buy";

            //}


            var lastCandle = candleResults.Last();




            if (lastCandle.Signal == Signal.BearSignal)
            {

                if (QuantConfirmationSginals < 4)
                {
                    QuantConfirmationSginals += 1;
                    LastSignal = "Bear";
                }

                if (QuantConfirmationSginals >= 4 && LastSignal == "Bear")
                {

                    if (LastCandlePrice == null)
                    {
                        LastCandlePrice = lastCandle.Price;
                    }
                    else
                    {
                        if (lastCandle.Price > LastCandlePrice )
                        {
                            Console.WriteLine("Marubuzu");

                            this.MakeAProposal(ContractType.PUT, 5, "t");
                            QuantConfirmationSginals = 0;
                            LastCandlePrice = null;
                            LastSignal = "";
                        }
                        else
                        {
                            QuantConfirmationSginals = 0;
                            LastCandlePrice = null;
                            LastSignal = "";
                        }
                    }


                }
                Action = "";

            }
            if (lastCandle.Signal == Signal.BullSignal)
            {
                if (QuantConfirmationSginals < 4)
                {
                    QuantConfirmationSginals += 1;
                    LastSignal = "Bull";
                }

                if (QuantConfirmationSginals >= 4 && LastSignal == "Bull")
                {

                    if (LastCandlePrice == null)
                    {
                        LastCandlePrice = lastCandle.Price;
                    }
                    else
                    {
                        if (lastCandle.Price < LastCandlePrice )
                        {
                            Console.WriteLine("Marubuzu");

                            this.MakeAProposal(ContractType.CALL, 5, "t");
                            QuantConfirmationSginals = 0;
                            LastCandlePrice = null;
                            LastSignal = "";

                        }
                        else
                        {
                            QuantConfirmationSginals = 0;
                            LastCandlePrice = null;
                            LastSignal = "";
                        }
                    }

               
                }
                Action = "";

            }



            //if (emaResults.Last().Ema > minuteBarQuotes.Last().Close && lastCandle.Signal == Signal.BearSignal && Action == "sell")
            //{
            //    this.MakeAProposal(ContractType.PUT, 2, "t");
            //    Action = "";

            //}
            //if (emaResults.Last().Ema < minuteBarQuotes.Last().Close && lastCandle.Signal == Signal.BullSignal && Action == "buy")
            //{
            //    this.MakeAProposal(ContractType.CALL, 2, "t");
            //    Action = "";

            //}
        }

        private void MakeAProposal(ContractType contract, int duration, string durationUnit)
        {
            _tradeService.MakeAProposal(contract, duration, durationUnit);
        }
    }

    public interface IMarubuzuRobot : IRobotOperations
    {
    }
}