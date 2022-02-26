using System.Transactions;
using DerivSmartRobot.Domain.Enums;
using Newtonsoft.Json;

namespace DerivSmartRobot.Models.DerivClasses;

public class Transaction
{
    [JsonProperty("action")]
    public ContractAction Action { get; set; }
    [JsonProperty("amount")]
    public decimal Amount { get; set; }
    [JsonProperty("balance")]
    public decimal Balance{ get; set; }
    [JsonProperty("barrier")]
    public string Barrier { get; set; }
    [JsonProperty("contract_id")]
    public long ContractId { get; set; }
    [JsonProperty("currency")]
    public string Currency { get; set; }
    [JsonProperty("date_expiry")]
    public long DateExpiry{ get; set; }
    [JsonProperty("display_name")]
    public string DisplayName { get; set; }
    [JsonProperty("id")]
    public Guid Id { get; set; }
    [JsonProperty("longcode")]
    public string LongCode { get; set; }
    [JsonProperty("symbol")]
    public string Symbol { get; set; }
    [JsonProperty("transaction_id")]
    public long TransactionId{ get; set; }
    [JsonProperty("transaction_time")]
    public long TransactionTime { get; set; }
}