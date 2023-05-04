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

    [DataMember(Order = 3), JsonProperty("individual", NullValueHandling = NullValueHandling.Ignore)]
    public Individual Individual { get; set; }
    
    [DataMember(Order = 4), JsonProperty("corporate", NullValueHandling = NullValueHandling.Ignore)]
    public Corporate Corporate{ get; set; }
}