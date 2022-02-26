using DerivSmartRobot.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DerivSmartRobot.Models.DerivClasses;

public class Tick
{
    public decimal Ask { get; set; }
    public decimal Bid { get; set; }
    public long Epoch { get; set; }
    public Guid Id { get; set; }
    [JsonProperty("pip_size")]
    public int PipSize { get; set; }
    public decimal Quote { get; set; }
    public string Symbol { get; set; }
}
