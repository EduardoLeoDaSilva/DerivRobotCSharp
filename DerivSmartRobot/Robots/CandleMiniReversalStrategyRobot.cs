using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Models.View;
using DerivSmartRobot.Services;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Robots
{
    public class CandleMiniReversalStrategyRobot : BaseRobot, IRobotOperations, ICandleMiniReversalStrategyRobot
    {
        private readonly ITradeService _tradeService;
        public int AuxCounterDirection;
        public ContractType? Contract { get; set; } = null;
        

        public CandleMiniReversalStrategyRobot(ITradeService tradeService) :base(tradeService)
        {
            _tradeService = tradeService;
        }
        public override void VerifyAndBuy(ResponseMessage message)
        {
            _tradeService.Log = new LogView { Date = DateTime.Now, Log = "Obtendo cotas" };

            var isToStop = base.IsToStopOperation();

            if(isToStop)
                return;
            var quote = this.BuildQuoteModel(message);
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

            var sar = minuteBarQuotes.GetParabolicSar();

            if (Contract != null)
            {
                _tradeService.Log.Log += $";Last: {candles.Last().Close}";
                _tradeService.Log.Log += $";Prior: {candles.TakeLast(2).First().Close}";


                if (candles.Last().Close < Quotes.TakeLast(2).First().Close && Contract == ContractType.PUT && sar.Last().Sar > candles.Last().Close)
                {
                    _tradeService.Log.Log += ";Realizando compra";
                    this.MakeAProposal(ContractType.PUT, 4, "t");
                    AuxCounterDirection = 1;
                    Contract = null;

                }
                else if(candles.Last().Close > Quotes.TakeLast(2).First().Close && Contract == ContractType.CALL && sar.Last().Sar < candles.Last().Close)
                {
                    _tradeService.Log.Log += ";Realizando compra";
                    this.MakeAProposal(ContractType.CALL, 4, "t");
                    AuxCounterDirection = 1;
                    Contract = null;
                }
                //else if(candles.Last().Close < Quotes.TakeLast(2).First().Close && Contract == ContractType.PUT)
                //{
                //    _tradeService.Log.Log += ";Aguardando confirmação de reversão.";
                //    Contract = ContractType.PUT;
                //    AuxCounterDirection += 1;
                //}else if (candles.Last().Close > Quotes.TakeLast(2).First().Close && Contract == ContractType.CALL)
                //{
                //    _tradeService.Log.Log += ";Aguardando confirmação de reversão.";
                //    Contract = ContractType.CALL;
                //    AuxCounterDirection += 1;
                //}
                else
                {
                    _tradeService.Log.Log += ";Reiniciando análise.";

                    Contract = null;
                    AuxCounterDirection = 1;
                }
            }

            if (candles.Last().IsBullish && candles.Last().Close > Quotes.TakeLast(2).First().Close &&
                candles.Last().BodyPct > 0.2)
            {
                if (AuxCounterDirection < 2)
                {
                    _tradeService.Log.Log += ";Mini direção contabilizada.";
                    AuxCounterDirection += 1;
                    return;;
                }

                if (AuxCounterDirection >= 2)
                {
                    _tradeService.Log.Log += ";Mini direção para cima concretizada";

                    this.Contract = ContractType.CALL;

                }
            }else if (candles.Last().IsBearish && candles.Last().Close < Quotes.TakeLast(2).First().Close &&
                      candles.Last().BodyPct > 0.2)
            {
                if (AuxCounterDirection < 2)
                {
                    _tradeService.Log.Log += ";Mini direção contabilizada.";
                    AuxCounterDirection += 1;
                    return; ;
                }


                if (AuxCounterDirection >= 2)
                {
                    this.Contract = ContractType.PUT;

                    _tradeService.Log.Log += ";Mini direção para baixo concretizada";


                }


            }
            else
            {
                AuxCounterDirection = 1;
                this.Contract = null;
            }
        }

        private void MakeAProposal(ContractType contract, int duration, string durationUnit)
        {
            _tradeService.MakeAProposal(contract, duration, durationUnit);
        }
    }

    public interface ICandleMiniReversalStrategyRobot : IRobotOperations
    {
    }
}
