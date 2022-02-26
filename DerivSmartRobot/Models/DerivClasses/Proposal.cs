using DerivSmartRobot.Domain.Enums;
using Newtonsoft.Json;

namespace DerivSmartRobot.Models.DerivClasses;

public class Proposal
{
    [JsonProperty("ask_price")]
    public double AskPrice { get; set; }
    [JsonProperty("date_expiry")]
    public long DateExpiry { get; set; }
    [JsonProperty("date_start")]
    public long DateStart { get; set; }
    [JsonProperty("display_value")]
    public string DisplayValue { get; set; }
    [JsonProperty("id")]
    public Guid Id { get; set; }
    [JsonProperty("longcode")]
    public string Longcode { get; set; }
    [JsonProperty("payout")]
    public double Payout { get; set; }
    [JsonProperty("spot")]
    public double Spot { get; set; }
    [JsonProperty("spot_time")]
    public long SpotTime { get; set; }
}