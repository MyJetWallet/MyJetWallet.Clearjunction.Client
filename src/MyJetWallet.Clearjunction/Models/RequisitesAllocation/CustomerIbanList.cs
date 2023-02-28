using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.RequisitesAllocation;

public class CustomerIbanList
{
    [JsonProperty("requestReference")]
    public string RequestReference { get; set; }

    [JsonProperty("clientCustomerId")]
    public string ClientCustomerId { get; set; }

    [JsonProperty("ibans")]
    public List<string> Ibans { get; set; }
}