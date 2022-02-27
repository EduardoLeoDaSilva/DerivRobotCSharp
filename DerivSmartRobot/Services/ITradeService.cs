using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Models.Classes;
using DerivSmartRobot.Models.DerivClasses;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Services;

public interface ITradeService
{
    OperationInfo currentOperation { get; set; }
    RobotConfigutarion RobotConfigutarion { get; set; }
    public bool IsOperating { get; set; }
    public List<Quote> QuotesCached { get; set; }


    bool SetConfigurationAndConnect(string token);
    bool MakeAProposal(ContractType contractType, int duration, string durationUnit, string? barrier = null);
    bool BuyAContract(Proposal proposal);
    void UpdateOperationInfoValues(ResponseMessage responseMessage);
}