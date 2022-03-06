using DerivSmartRobot.Domain.Enums;

namespace DerivSmartRobot.Models.Classes
{
    public class RobotConfigutarion
    {
        public string Market { get; set; }
        public decimal Stake { get; set; }
        public RobotType RobotType { get; set; }
        public decimal StopWin { get; set; }
        public decimal StopLoss { get; set; }
        public int MaxLossSequence { get; set; }
        public decimal MaxLossSequenceAfterThisProfit { get; set; }
        public MartingaleType MartigaleType { get; set; } = MartingaleType.Normal;
        public decimal MartingaleValue { get; set; }

        public RobotType? CalledFrom { get; set; } = null;
    }
}