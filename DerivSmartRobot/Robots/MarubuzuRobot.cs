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


        public decimal PriorQuote { get; set; }

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

            var wma = minuteBarQuotes.GetWma(14);


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

            _tradeService.Log = new LogView { Date = DateTime.Now, Log = "Analisando..." };


            if (candles.Last().IsBearish && candles.Last().Size > 0.20M && candles.Last().BodyPct >=(double)0.50 && string.IsNullOrEmpty(LastSignal))
            {
                PriorQuote = candles.Last().Close;

                LastSignal = "bear";

            }else if (LastSignal == "bear")
            {
                _tradeService.Log.Log += $";Sinal de venda";
                _tradeService.Log.Log += $";Aguardando confirmação...";


                if (PriorQuote < candles.Last().Close)
                {
                    PriorQuote = candles.Last().Close;
                    QuantConfirmationSginals += 1;

                }
                else
                {
                    QuantConfirmationSginals = 0;
                    LastSignal = "";
                    _tradeService.Log.Log += $";Reiniciando análise";

                }

                if (QuantConfirmationSginals >= 2)
                {
                    _tradeService.Log.Log += $";Sinal Confirmado!";

                    PriorQuote = candles.Last().Close;
                    _tradeService.Log.Log += ";Analisando WMA";

                    if (wma.Last().Wma > candles.TakeLast(2).First().High && wma.Last().Wma > candles.Last().High)
                    {
                        _tradeService.Log.Log += ";Realizando compra";


                        this.MakeAProposal(ContractType.PUT, 1, "t");
                    }


                    QuantConfirmationSginals = 0;
                    LastSignal = "";
                }
            }


            if (candles.Last().IsBullish && candles.Last().Size > 0.20M && candles.Last().BodyPct >= (double)0.50 && string.IsNullOrEmpty(LastSignal))
            {
                PriorQuote = candles.Last().Close;

                LastSignal = "bull";

            }
            else if (LastSignal == "bull")
            {
                _tradeService.Log.Log += $";Sinal de compra";
                _tradeService.Log.Log += $";Aguardando confirmação...";
                if (PriorQuote > candles.Last().Close)
                {
                    PriorQuote = candles.Last().Close;
                    QuantConfirmationSginals += 1;
                }
                else
                {
                    QuantConfirmationSginals = 0;
                    LastSignal = "";
                    _tradeService.Log.Log += $";Reiniciando análise";

                }

                if (QuantConfirmationSginals >= 2)
                {
                    _tradeService.Log.Log += $";Sinal Confirmado!";

                    PriorQuote = candles.Last().Close;
                    _tradeService.Log.Log += ";Analisando WMA";

                    if (wma.Last().Wma < candles.TakeLast(2).First().Low && wma.Last().Wma < candles.Last().Low)
                    {
                        _tradeService.Log.Log += ";Realizando compra";
                        this.MakeAProposal(ContractType.CALL, 1, "t");
                    }

                    QuantConfirmationSginals = 0;
                    LastSignal = "";
                }
            }

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