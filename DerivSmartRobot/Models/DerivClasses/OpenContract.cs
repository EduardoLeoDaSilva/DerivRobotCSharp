using Newtonsoft.Json;

namespace DerivSmartRobot.Models.DerivClasses
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class ContractEnd
    {
        [JsonProperty("epoch")]
        public int Epoch { get; set; }

        [JsonProperty("tick")]
        public double Tick { get; set; }

        [JsonProperty("tick_display_value")]
        public string TickDisplayValue { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ContractStart
    {
        [JsonProperty("epoch")]
        public int Epoch { get; set; }

        [JsonProperty("tick")]
        public double Tick { get; set; }

        [JsonProperty("tick_display_value")]
        public string TickDisplayValue { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class AuditDetails
    {
        [JsonProperty("contract_end")]
        public List<ContractEnd> ContractEnd { get; set; }

        [JsonProperty("contract_start")]
        public List<ContractStart> ContractStart { get; set; }
    }

    public class TransactionIds
    {
        [JsonProperty("buy")]
        public long Buy { get; set; }

        [JsonProperty("sell")]
        public long Sell { get; set; }
    }

    public class ProposalOpenContract
    {
        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        [JsonProperty("audit_details")]
        public AuditDetails AuditDetails { get; set; }

        [JsonProperty("barrier")]
        public string Barrier { get; set; }

        [JsonProperty("barrier_count")]
        public int BarrierCount { get; set; }

        [JsonProperty("bid_price")]
        public decimal BidPrice { get; set; }

        [JsonProperty("buy_price")]
        public double BuyPrice { get; set; }

        [JsonProperty("contract_id")]
        public long ContractId { get; set; }

        [JsonProperty("contract_type")]
        public string ContractType { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("current_spot")]
        public double CurrentSpot { get; set; }

        [JsonProperty("current_spot_display_value")]
        public string CurrentSpotDisplayValue { get; set; }

        [JsonProperty("current_spot_time")]
        public int CurrentSpotTime { get; set; }

        [JsonProperty("date_expiry")]
        public int DateExpiry { get; set; }

        [JsonProperty("date_settlement")]
        public int DateSettlement { get; set; }

        [JsonProperty("date_start")]
        public int DateStart { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("entry_spot")]
        public double EntrySpot { get; set; }

        [JsonProperty("entry_spot_display_value")]
        public string EntrySpotDisplayValue { get; set; }

        [JsonProperty("entry_tick")]
        public double EntryTick { get; set; }

        [JsonProperty("entry_tick_display_value")]
        public string EntryTickDisplayValue { get; set; }

        [JsonProperty("entry_tick_time")]
        public int EntryTickTime { get; set; }

        [JsonProperty("exit_tick")]
        public double ExitTick { get; set; }

        [JsonProperty("exit_tick_display_value")]
        public string ExitTickDisplayValue { get; set; }

        [JsonProperty("exit_tick_time")]
        public int ExitTickTime { get; set; }

        [JsonProperty("expiry_time")]
        public int ExpiryTime { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_expired")]
        public bool IsExpired { get; set; }

        [JsonProperty("is_forward_starting")]
        public int IsForwardStarting { get; set; }

        [JsonProperty("is_intraday")]
        public int IsIntraday { get; set; }

        [JsonProperty("is_path_dependent")]
        public int IsPathDependent { get; set; }

        [JsonProperty("is_settleable")]
        public int IsSettleable { get; set; }

        [JsonProperty("is_sold")]
        public int IsSold { get; set; }

        [JsonProperty("is_valid_to_cancel")]
        public int IsValidToCancel { get; set; }

        [JsonProperty("is_valid_to_sell")]
        public bool IsValidToSell { get; set; }

        [JsonProperty("longcode")]
        public string Longcode { get; set; }

        [JsonProperty("payout")]
        public decimal Payout { get; set; }

        [JsonProperty("profit")]
        public double Profit { get; set; }

        [JsonProperty("profit_percentage")]
        public double ProfitPercentage { get; set; }

        [JsonProperty("purchase_time")]
        public int PurchaseTime { get; set; }

        [JsonProperty("sell_price")]
        public decimal SellPrice { get; set; }

        [JsonProperty("sell_spot")]
        public double SellSpot { get; set; }

        [JsonProperty("sell_spot_display_value")]
        public string SellSpotDisplayValue { get; set; }

        [JsonProperty("sell_spot_time")]
        public int SellSpotTime { get; set; }

        [JsonProperty("sell_time")]
        public int SellTime { get; set; }

        [JsonProperty("shortcode")]
        public string Shortcode { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("transaction_ids")]
        public TransactionIds TransactionIds { get; set; }

        [JsonProperty("underlying")]
        public string Underlying { get; set; }

        [JsonProperty("validation_error")]
        public string ValidationError { get; set; }
    }

}
