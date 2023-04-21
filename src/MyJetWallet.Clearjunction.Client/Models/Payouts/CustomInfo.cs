using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class CustomInfo
{
    [DataMember(Order = 1), JsonProperty("withdrawalTransactionId", NullValueHandling = NullValueHandling.Ignore)]
    public string WithdrawalTransactionId { get; set; }

    [DataMember(Order = 2), JsonProperty("clientId", NullValueHandling = NullValueHandling.Ignore)]
    public string ClientId { get; set; }
}