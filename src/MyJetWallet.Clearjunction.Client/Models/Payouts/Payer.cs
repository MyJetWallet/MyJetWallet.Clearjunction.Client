using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class Payer
{
    [DataMember(Order = 1), JsonProperty("clientCustomerId")]
    public string ClientCustomerId { get; set; }

    [DataMember(Order = 2), JsonProperty("walletUuid")]
    public string WalletUuid { get; set; }

    [DataMember(Order = 3), JsonProperty("individual",  NullValueHandling = NullValueHandling.Ignore)]
    public Individual Individual { get; set; }
    
    [DataMember(Order = 4), JsonProperty("corporate", NullValueHandling = NullValueHandling.Ignore)]
    public Corporate Corporate{ get; set; }
}