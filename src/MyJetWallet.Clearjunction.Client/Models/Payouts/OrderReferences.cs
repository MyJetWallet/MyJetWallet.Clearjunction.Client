using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class OrderReferences
{
    [DataMember(Order = 1), JsonProperty("orderReferenceArray")]
    public string[] Orders { get; set; }
}