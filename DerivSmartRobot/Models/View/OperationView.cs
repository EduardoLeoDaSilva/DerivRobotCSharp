using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DerivSmartRobot.Domain.Enums;

namespace DerivSmartRobot.Models.View
{
    public class OperationView
    {
        public string ContractId { get; set; }
        public string Market { get; set; }
        public ContractType Contract { get; set; }

        public decimal Amount { get; set; }

        public decimal Profit { get; set; }

        public ContractAction Action { get; set; }

        public decimal Duration { get; set; }

        public string DurationType { get; set; }
    }
}
