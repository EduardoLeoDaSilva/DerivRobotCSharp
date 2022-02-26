using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Models.Classes;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Redis;

namespace DerivSmartRobot.Services;

public class TradeService : ITradeService
{
    public OperationInfo currentOperation { get; set; }
    public RobotConfigutarion RobotConfigutarion { get; set; }

    private readonly IClientDeriv _client;
    public bool IsOperating { get; set; } = false;

    public TradeService(IClientDeriv client)
    {
        _client = client;
    }

    public bool SetConfigurationAndConnect(string token)
    {
        _client.SetConfigurations("1089", token);
        _client.Connect();
        _client.Authorize();
        return true;
    }

    public bool MakeAProposal(ContractType contractType, int duration, string durationUnit, decimal? barrier = null)
    {
        if (IsOperating)
            return true;
        
        var amount = Convert.ToDecimal(string.Format("{0:F2}",currentOperation.NewAmount != 0 ? currentOperation.NewAmount : RobotConfigutarion.Stake));
        var contract = CommandsService.GetCommands(CommandsApi.Proposal,
            CommandsService.BuildContractModel(1,  currentOperation.NewAmount != 0 ? currentOperation.NewAmount :RobotConfigutarion.Stake, barrier, "stake", contractType.ToString(),
                "USD", duration, durationUnit, RobotConfigutarion.Market));

        currentOperation.LastValueLost = amount;
        IsOperating = true;
        _client.SendCommand(contract);

        return true;
    }

    public bool BuyAContract(Proposal proposal)
    {
        var buy = CommandsService.GetCommands(CommandsApi.Buy, proposal);
        _client.SendCommand(buy);
        return true;
    }

    public void UpdateOperationInfoValues(ResponseMessage responseMessage)
    {
        if (responseMessage.Transaction.TransactionId is 0)
            return;
        if(responseMessage.Transaction.Action == ContractAction.Buy)
            return;
        
        if (responseMessage.Transaction.Amount == 0)
        {
            currentOperation.QuantLoss += 1;
            currentOperation.LossToRecover += currentOperation.LastValueLost;
            currentOperation.CurrentOperationBalance += currentOperation.LastValueLost *-1;
        }

        if (responseMessage.Transaction.Amount > 0)
        {
            currentOperation.QuantWin += 1;
            currentOperation.LossToRecover = 0;
            currentOperation.CurrentOperationBalance += responseMessage.Transaction.Amount- currentOperation.LastValueLost;
            currentOperation.LastValueLost = 0;
        }

        currentOperation.RobotAccuracy = (currentOperation.QuantWin * 100) /
                                         (currentOperation.QuantLoss + currentOperation.QuantWin);
        
        Console.WriteLine("Wins   Loss     %Ac     OperationBalance");
        
        Console.WriteLine($"{currentOperation.QuantWin}        {currentOperation.QuantLoss}            {currentOperation.RobotAccuracy}          {currentOperation.CurrentOperationBalance}  ");


    }
}