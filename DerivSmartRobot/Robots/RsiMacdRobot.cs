using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Models.View;
using DerivSmartRobot.Services;
using Skender.Stock.Indicators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DerivSmartRobot.Robots
{
    public interface IRsiMacdRobot : IRobotOperations
    {
    }

    public class RsiMacdRobot : BaseRobot, IRobotOperations, IRsiMacdRobot
    {
        private readonly ITradeService _tradeService;
        public DateTime LastRsiSignalDate { get; set; }
        public string RsiLastSignal { get; set; }


        public RsiMacdRobot(ITradeService tradeService) : base(tradeService)
        {
            _tradeService = tradeService;
        }

        public override void VerifyAndBuy(ResponseMessage message)
        {
            var quote = this.BuildQuoteModel(message);
            Quotes.Add(quote);


            this._tradeService.Log = this._tradeService.Log = new LogView { Date = DateTime.Now, Log = "Verificando cotas" };

            IEnumerable<Quote> minuteBarQuotes =
                Quotes.Aggregate(TimeSpan.FromMinutes(5));

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

            var rsi = minuteBarQuotes.GetRsi();
            var macd = minuteBarQuotes.GetMacd();

            this._tradeService.Log.Log += $";RSI: {rsi.Last().Rsi}";
            this._tradeService.Log.Log += $";LastRsiSignalDeadLine: {LastRsiSignalDate:G}";
            this._tradeService.Log.Log += $";MACD histogram: {macd.Last().Histogram}";





            if (rsi.Last().Rsi > 70)
            {
                RsiLastSignal = "sell";
                LastRsiSignalDate = DateTime.Now.AddMinutes(15);

            }else if(rsi.Last().Rsi < 30){
                RsiLastSignal = "buy";
                LastRsiSignalDate = DateTime.Now.AddMinutes(15);
            }

            if (macd.Last().Macd > macd.Last().Signal && macd.Last().Histogram < 0.589M
                && RsiLastSignal == "buy" && LastRsiSignalDate < DateTime.Now)
            {
               _tradeService.MakeAProposal(ContractType.CALL, 5, "m", null);
                //buy
            }

            if (macd.Last().Signal > macd.Last().Macd && macd.Last().Histogram > -0.589M
                && RsiLastSignal == "sell" && LastRsiSignalDate < DateTime.Now)
            {
                _tradeService.MakeAProposal(ContractType.PUT, 5, "m", null);
                //sell
            }

        }

        public void MakeAProposal(ContractType contract, int duration, string durationUnit, string? barrier)
        {
            _tradeService.MakeAProposal(contract, duration, durationUnit, barrier);

        }
    }
}
