using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Wallet;

[DataContract]
public class PaymentMethod
{
    [DataMember(Order = 1), JsonProperty("type")]
    public string Type { get; set; }
        
    [DataMember(Order = 2), JsonProperty("bankCode")]
    public string BankCode { get; set; }
        
    [DataMember(Order = 3), JsonProperty("accountNumber")]
    public string AccountNumber { get; set; }
        
    [DataMember(Order = 4), JsonProperty("name")]
    public string Name { get; set; }
}