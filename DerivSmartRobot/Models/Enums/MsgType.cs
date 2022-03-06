using Newtonsoft.Json;

namespace DerivSmartRobot.Domain.Enums
{
    public enum MsgType
    {
        [JsonProperty("active_symbols")]
        ActiveSymbols,
        [JsonProperty("authorize")]
        Authorize,
        [JsonProperty("history")]
        History,
        [JsonProperty("balance")]
        Balance,
        [JsonProperty("tick")]
        Tick,
        [JsonProperty("transaction")]
        Transaction,
        [JsonProperty("proposal")]
        Proposal,
        [JsonProperty("buy")]
        Buy,
        [JsonProperty("ohlc")]
        Ohlc,
        [JsonProperty("candles")]
        Candles
    }
}