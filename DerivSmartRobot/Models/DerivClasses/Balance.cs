using DerivSmartRobot.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DerivSmartRobot.Models.DerivClasses
{
    public class Balance
    {
        [JsonProperty("balance")]
        public decimal BalanceDeriv { get; set; }
        public string USD { get; set; }
        public Guid Id { get; set; }//Id da subscription tbm
        [JsonProperty("loginid")]
        public string LoginId { get; set; }
    }
}