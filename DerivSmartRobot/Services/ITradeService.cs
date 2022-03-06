using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Models.Classes;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Models.View;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Services
{
    public interface ITradeService
    {
        OperationInfo currentOperation { get; set; }
        RobotConfigutarion RobotConfigutarion { get; set; }
        public bool IsOperating { get; set; }
        public List<Quote> QuotesCached { get; set; }
        public OperationView Operation { get; set; }

        public LogView Log { get; set; }
        bool SetConfigurationAndConnect(string token);
        bool MakeAProposal(ContractType contractType, int duration, string durationUnit, string? barrier = null);
        bool BuyAContract(Proposal proposal);
        void UpdateOperationInfoValues(ResponseMessage responseMessage);
        ModelToView GetOperations();
        void UpdateBalance(ResponseMessage responseMessage);
        void StopOperation();
    }
}