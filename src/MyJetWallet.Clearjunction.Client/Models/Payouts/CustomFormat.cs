using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class CustomFormat
{
    [DataMember(Order = 1), JsonProperty("clientCustomAttributeExample")]
    public string ClientCustomAttributeExample { get; set; }
}