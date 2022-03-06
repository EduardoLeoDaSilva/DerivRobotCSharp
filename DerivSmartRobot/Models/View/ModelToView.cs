using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DerivSmartRobot.Models.Classes;

namespace DerivSmartRobot.Models.View
{
    public class ModelToView
    {
        public OperationView Operation { get; set; }
        public BalanceView Balance { get; set; }

        public OperationInfo OperationInfo { get; set; }
        public RobotConfigutarion RobotConfigutarion { get; set; }
        public LogView Log { get; set; }
    }
}
