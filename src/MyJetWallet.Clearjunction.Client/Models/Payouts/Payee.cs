using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class Payee
{
    [DataMember(Order = 1), JsonProperty("clientCustomerId", NullValueHandling = NullValueHandling.Ignore)]
    public string ClientCustomerId { get; set; }

    [DataMember(Order = 2), JsonProperty("walletUuid", NullValueHandling = NullValueHandling.Ignore)]
    public string WalletUuid { get; set; }

    [DataMember(Order = 3), JsonProperty("individual")]
    public Individual Individual { get; set; }
}