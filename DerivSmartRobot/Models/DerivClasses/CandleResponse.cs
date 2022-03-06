using Newtonsoft.Json;

namespace DerivSmartRobot.Models.DerivClasses
{
    public class CandleResponse
    {
        [JsonProperty("close")]
        public decimal Close { get; set; }
        [JsonProperty("epoch")]
        public int Epoch { get; set; }
        [JsonProperty("high")]
        public decimal High { get; set; }
        [JsonProperty("low")]
        public decimal Low { get; set; }
        [JsonProperty("open")]
        public decimal Open { get; set; }
    }
}