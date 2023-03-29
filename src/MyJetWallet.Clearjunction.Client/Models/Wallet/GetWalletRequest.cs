using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Wallet;

[DataContract]
public class GetWalletRequest
{
    [DataMember(Order = 1), JsonProperty("walletUuid")]
    public string WalletUuid { get; set; }
}