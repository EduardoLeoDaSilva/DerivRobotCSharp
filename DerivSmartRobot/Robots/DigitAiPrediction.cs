using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Models.NewFolder;
using DerivSmartRobot.Models.View;
using DerivSmartRobot.Services;

namespace DerivSmartRobot.Robots
{
    public class DigitAiPrediction : BaseRobot, IRobotOperations, IDigitAiPrediction
    {
        private readonly ITradeService _tradeService;
        private readonly AIService _aiService;
        private DateTime LasBoughtDate;

        private Dictionary<int, int> quantDigitos = new Dictionary<int, int> { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }, { 9, 0 } };
        public DigitAiPrediction(ITradeService tradeService, AIService aiService) : base(tradeService)
        {
            _tradeService = tradeService;
            _aiService = aiService;
        }

        public override async void VerifyAndBuy(ResponseMessage message)
        {
            var quote = this.BuildQuoteModel(message);
            Quotes.Add(quote);


            //if (_tradeService.currentOperation.LossToRecover > 0)
            //{
            //    _tradeService.RobotConfigutarion.RobotType = RobotType.RSI;
            //    _tradeService.RobotConfigutarion.CalledFrom = RobotType.Digit;
            //    _tradeService.QuotesCached = Quotes;
            //    return;
            //}

            var quoteStringcurrent = quote.Close.ToString("F" + message.Ohlc.Pip_size);
            var currentLastDigit = quoteStringcurrent.Substring(quoteStringcurrent.Length - 1, 1);
            quantDigitos.Clear();

            quantDigitos = new Dictionary<int, int> { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }, { 9, 0 } };

            foreach (var quotet in Quotes.TakeLast(10))
            {
                var quoteString = quotet.Close.ToString("F" + message.Ohlc.Pip_size);
                var number = int.Parse(quoteString.Substring(quoteString.Length - 1, 1));
                quantDigitos[number] += 1;
            }

            if (quantDigitos[8] + quantDigitos[9] +  quantDigitos[7]> 5 && int.Parse(currentLastDigit) >6)
            {
                if(DateTime.Now > LasBoughtDate)
                {

                LasBoughtDate = DateTime.Now.AddMinutes(1);
                this.MakeAProposal(ContractType.DIGITUNDER, 1, "t", "7");

                }
            }
            

            var keyOfMaxValue = quantDigitos.Aggregate((x, y) => x.Value < y.Value ? x : y).Key;
            
            // this._tradeService.Log.Log += $"; Predição : {keyOfMaxValue}";
            //
            // if (int.Parse(currentLastDigit) == keyOfMaxValue)
            // {
            //     this.MakeAProposal(ContractType.DIGITDIFF, 1, "t", keyOfMaxValue.ToString());
            // }


        }


        public void MakeAProposal(ContractType contract, int duration, string durationUnit, string? barrier)
        {
            _tradeService.MakeAProposal(contract, duration, durationUnit, barrier);

        }
    }

    public interface IDigitAiPrediction : IRobotOperations
    {
    }
}
