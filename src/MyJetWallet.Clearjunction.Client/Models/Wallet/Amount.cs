using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Wallet;

[DataContract]
public class Amount
{
    [DataMember(Order = 1), JsonProperty("currencyCode")]
    public string CurrencyCode { get; set; }
        
    [DataMember(Order = 2), JsonProperty("availableFunds")]
    public int  AvailableFunds { get; set; }
}