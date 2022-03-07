using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Models.View;
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

        public int RetraceBuyNow { get; set; } = 0;

        public decimal? LastCandlePrice { get; set; } = null;

        public MarubuzuRobot(ITradeService tradeService) : base(tradeService)
        {
            _tradeService = tradeService;
        }
        public override void VerifyAndBuy(ResponseMessage message)
        {

            var quote = this.BuildQuoteModel(message);
            Quotes.Add(quote);

            IEnumerable<Quote> minuteBarQuotes =
                Quotes.Aggregate(TimeSpan.FromMinutes(1));

            var emaResults = minuteBarQuotes.GetEma(100);


            var stochRsi = minuteBarQuotes.GetRsi();

            var ema = minuteBarQuotes.GetEma(100);


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

            //if (string.IsNullOrEmpty(Action) && stochRsi.Last().Rsi >= 70)
            //{
            //    Action = "sell";
            //}

            //if (string.IsNullOrEmpty(Action) && stochRsi.Last().Rsi <= 30)
            //{
            //    Action = "buy";

            //}




            _tradeService.Log = new LogView { Date = DateTime.Now, Log = "Analisando..." };
            _tradeService.Log.Log += $"{candles.Last().Size}";


            if (candles.Last().IsBearish && candles.Last().Body > 0.50M)
            {

                if (QuantConfirmationSginals <2)
                {
                    QuantConfirmationSginals += 1;
                    LastSignal = "Bear";
                    _tradeService.Log.Log += ";Contabilizando canddle sentido para baixo";
                }

                if (QuantConfirmationSginals >= 2 && LastSignal == "Bear")
                {

                    if (Quotes.Last().Close > Quotes.TakeLast(2).First().Close)
                    {
                        RetraceBuyNow += 1;
                    }
                    else
                    {
                        QuantConfirmationSginals = 0;
                        LastCandlePrice = null;
                        LastSignal = "";
                    }


                    if (RetraceBuyNow >= 2)
                    {
                        _tradeService.Log.Log += ";Realizando compra";


                        this.MakeAProposal(ContractType.PUT, 3, "t");
                        QuantConfirmationSginals = 0;
                        LastCandlePrice = null;
                        LastSignal = "";
                    }
                    



                }
                else
                {
                    QuantConfirmationSginals = 0;
                    LastCandlePrice = null;
                    LastSignal = "";
                    RetraceBuyNow = 0;
                }
                Action = "";

            }
            if (candles.Last().IsBullish && candles.Last().Body > 0.50M)
            {
                if (QuantConfirmationSginals < 2)
                {
                    QuantConfirmationSginals += 1;
                    LastSignal = "Bull";
                    _tradeService.Log.Log += ";Contabilizando canddle sentido para cima";


                }

                if (QuantConfirmationSginals >= 2 && LastSignal == "Bull")
                {
                    if (Quotes.Last().Close < Quotes.TakeLast(2).First().Close)
                    {
                        RetraceBuyNow += 1;

                    }
                    else
                    {
                        QuantConfirmationSginals = 0;
                        LastCandlePrice = null;
                        LastSignal = "";
                        RetraceBuyNow = 0;
                    }
                    if (RetraceBuyNow >= 2)
                    {

                        _tradeService.Log.Log += ";Realizando compra";

                        this.MakeAProposal(ContractType.CALL, 3, "t");
                        QuantConfirmationSginals = 0;
                        LastCandlePrice = null;
                        LastSignal = "";

                    }




                }
                Action = "";

            }
            else
            {
                QuantConfirmationSginals = 0;
                LastCandlePrice = null;
                LastSignal = "";
                RetraceBuyNow = 0;
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