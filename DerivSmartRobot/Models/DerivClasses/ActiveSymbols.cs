using DerivSmartRobot.Domain.Enums;
using Newtonsoft.Json;

namespace DerivSmartRobot.Models.DerivClasses
{
    public class ActiveSymbol
    {
        [JsonProperty("allow_forward_starting")]
        public bool AllowForwardStarting { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("exchange_is_open")]
        public bool ExchangeIsOpen { get; set; }
        [JsonProperty("is_trading_suspended")]
        public bool IsTradingSuspended { get; set; }
        [JsonProperty("market")]
        public string Market { get; set; }
        [JsonProperty("market_display_name")]
        public string MarketDisplayName { get; set; }
        [JsonProperty("pip")]
        public double Pip { get; set; }
        [JsonProperty("submarket")]
        public string SubMarket { get; set; }
        [JsonProperty("submarket_display_name")]
        public string SubMarketDisplayName { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("symbol_type")]
        public string SymbolType { get; set; }
    }
}