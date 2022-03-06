using Newtonsoft.Json;

namespace DerivSmartRobot.Models.DerivClasses
{
    public class Contract
    {
        [JsonProperty("proposal")]
        public int?  Proposal  { get; set; }
        [JsonProperty("amount")]
        public decimal? Amount { get; set; }
        [JsonProperty("barrier")]
        public string? Barrier  { get; set; }
        [JsonProperty("basis")]
        public string? Basis { get; set; } = "stake";
        [JsonProperty("contract_type")]
        public string? Contract_type { get; set; }
        [JsonProperty("currency")]
        public string? Currency  { get; set; }
        [JsonProperty("duration")]
        public int? Duration  { get; set; }
        [JsonProperty("duration_unit")]
        public string? Duration_unit  { get; set; }
        [JsonProperty("symbol")]
        public string? Symbol { get; set; }
    }
}