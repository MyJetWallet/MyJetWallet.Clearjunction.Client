using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Wallet;

[DataContract]
public class PaymentMethod
{
    [DataMember(Order = 1), JsonProperty("type")]
    public string Type { get; set; }
        
    [DataMember(Order = 1), JsonProperty("bankCode")]
    public string BankCode { get; set; }
        
    [DataMember(Order = 1), JsonProperty("accountNumber")]
    public string AccountNumber { get; set; }
        
    [DataMember(Order = 1), JsonProperty("name")]
    public string Name { get; set; }
}