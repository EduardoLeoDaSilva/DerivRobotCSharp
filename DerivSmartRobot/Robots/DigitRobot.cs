using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Services;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Robots;

public interface IDigitRobotRobot : IRobotOperations
{
}

public class DigitRobot :BaseRobot, IRobotOperations, IDigitRobotRobot
{

    public int TimesRepeated { get; set; } = 0;
    public int QuantAbove5{ get; set; }

    public List<int> AvailableNumbers { get; set; } = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    public int? PriorLastDigit { get; set; } = null;

    private readonly ITradeService _tradeService;

    public DigitRobot(ITradeService tradeService)
    {
        _tradeService = tradeService;
    }

    public void VerifyAndBuy(ResponseMessage message)
    {
        var quote  = this.BuildQuoteModel(message);
        Quotes.Add(quote);

        if (_tradeService.currentOperation.LossToRecover > 0)
        {
            _tradeService.RobotConfigutarion.RobotType = RobotType.RSI;
            _tradeService.RobotConfigutarion.CalledFrom = RobotType.Digit;
            _tradeService.QuotesCached = Quotes;
            return;
        }

        var quoteString = quote.Close.ToString("F"+ message.Ohlc.Pip_size);
        var currentLastDigit = quoteString.Substring(quoteString.Length - 1, 1);
        
        if(!AvailableNumbers.Any())
            AvailableNumbers = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

        if (PriorLastDigit == null)
        {
            PriorLastDigit = int.Parse(currentLastDigit);
            return;
        }
        
        if (TimesRepeated >= 2)
        {
            TimesRepeated = 0;
            this.MakeAProposal(ContractType.DIGITDIFF, new Random().Next(1,3), "t", PriorLastDigit.Value.ToString());
            // AvailableNumbers.Remove(PriorLastDigit.Value);
        }

        if (PriorLastDigit == int.Parse(currentLastDigit) && AvailableNumbers.Contains(int.Parse(currentLastDigit)))
        {
            TimesRepeated += 1;
        }
        else
        {
            TimesRepeated = 1;
        }

        PriorLastDigit = int.Parse(currentLastDigit);

    }

    public void MakeAProposal(ContractType contract, int duration, string durationUnit, string? barrier)
    {
        _tradeService.MakeAProposal(contract, duration, durationUnit, barrier);

    }

    public void Buy(ResponseMessage message)
    {
        throw new NotImplementedException();
    }

    public void StopOperation()
    {
        throw new NotImplementedException();
    }
}