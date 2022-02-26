using DerivSmartRobot.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DerivSmartRobot.Models.DerivClasses;

public class AuthorizeResponse
{
    [JsonProperty("account_list")]
    public List<AccountListResponse> AccountList { get; set; }

    public double Balance { get; set; }
    public string Country { get; set; }
    public string Currency { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    [JsonProperty("is_virtual")]
    public bool IsVirtual { get; set; }
    [JsonProperty("landing_company_fullname")]
    public string LandingCompanyFullName { get; set; }
    [JsonProperty("landing_company_name")]
    public string LandingCompanyName { get; set; }
    [JsonProperty("local_currencies")]
    public LocalCurrencies LocalCurrencies { get; set; }

    public string LoginId { get; set; }
    [JsonProperty("preferred_language")]
    public string PreferredLanguage { get; set; }

    public List<string> Scopes { get; set; }
    public dynamic Trading { get; set; }
    [JsonProperty("user_id")]
    public int UserId { get; set; }
}

public class AccountListResponse{

    [JsonProperty("account_type")]
    public string Accounttype { get; set; }
    public string Currency { get; set; }
    [JsonProperty("is_disabled")]
    public bool IsDisabled { get; set; }
    [JsonProperty("is_virtual")]
    public bool IsVirtual { get; set; }
    [JsonProperty("landing_company_name")]
    public string LandingCompanyName { get; set; }
    public dynamic Trading { get; set; }
}

public class LocalCurrencies
{
    public Currency BRL { get; set; }
}

public class Currency
{
    [JsonProperty("fractional_digits")]
    public int FractionalDigits {get; set; }
}