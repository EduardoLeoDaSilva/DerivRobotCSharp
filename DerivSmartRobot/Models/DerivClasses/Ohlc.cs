using Newtonsoft.Json;

namespace DerivSmartRobot.Models.DerivClasses
{
    public class Ohlc
    {
        [JsonProperty("close")]
        public decimal Close { get; set; }
        [JsonProperty("epoch")]
        public int Epoch { get; set; }
        [JsonProperty("granularity")]
        public int Granularity { get; set; }
        [JsonProperty("high")]
        public decimal High { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("low")]
        public decimal Low { get; set; }
        [JsonProperty("open")]
        public decimal Open { get; set; }
        [JsonProperty("open_time")]
        public int Open_time { get; set; }
        [JsonProperty("pip_size")]
        public int Pip_size { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}