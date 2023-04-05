using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payins;

[DataContract]
public class Payee
{
    [DataMember(Order = 1), JsonProperty("walletUuid")]
    public string WalletUuid { get; set; }

    [DataMember(Order = 2), JsonProperty("clientCustomerId")]
    public string ClientCustomerId { get; set; }
}