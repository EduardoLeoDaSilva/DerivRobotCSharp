namespace DerivSmartRobot.Models.Classes
{
    public class OperationInfo
    {
        public decimal Balance { get; set; }

        public decimal CurrentOperationBalance { get; set; }
        public int QuantWin { get; set; }
        public int QuantLoss { get; set; }
        public double RobotAccuracy { get; set; }
        public decimal LossToRecover { get; set; }
        public decimal LastValueLost { get; set; }
        public decimal NewAmount { get; set; }

        public string AccessToken { get; set; }

    }
}