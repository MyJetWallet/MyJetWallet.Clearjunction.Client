using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class MyExampleObject1
{
    [DataMember(Order = 1), JsonProperty("MyExampleParam2")]
    public string MyExampleParam2 { get; set; }

    [DataMember(Order = 2), JsonProperty("MyExampleParam3")]
    public string MyExampleParam3 { get; set; }
}