using DerivSmartRobot.Domain.Enums;
using Newtonsoft.Json;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Models.DerivClasses
{
    public class ResponseMessage
    {
        [JsonProperty("msg_type")]
        public MsgType MsgType { get; set; }
    
        [JsonProperty("active_symbols")]
        public List<ActiveSymbol> ActiveSymbol { get; set; }
        public AuthorizeResponse Authorize { get; set; }
        public Balance Balance { get; set; }
        public Subscription Subscription { get; set; }
        public History History { get; set; }
        public BuyResponse Buy { get; set; }

        [JsonProperty("error")]
        public ErrorResponse Error { get; set; }
        public Proposal  Proposal { get; set; }
        [JsonProperty("tick")]
        public Tick Tick { get; set; }
        public Transaction Transaction { get; set; }
    
        [JsonProperty("candles")]
        public List<CandleResponse> Candles { get; set; }

        [JsonProperty("ohlc")]
        public Ohlc Ohlc { get; set; }
    }
}