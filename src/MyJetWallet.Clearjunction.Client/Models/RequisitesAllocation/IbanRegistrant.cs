using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.RequisitesAllocation;

[DataContract]
public class IbanRegistrant
{
    [DataMember(Order = 1), JsonProperty("clientCustomerId")]
    public string ClientCustomerId { get; set; }

    [DataMember(Order = 2), JsonProperty("name")]
    public string Name { get; set; }
}