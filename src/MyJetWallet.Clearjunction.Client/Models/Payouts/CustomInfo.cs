using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class CustomInfo
{
    [DataMember(Order = 1), JsonProperty("MyExampleParam1")]
    public string MyExampleParam1 { get; set; }

    [DataMember(Order = 2), JsonProperty("MyExampleObject1")]
    public MyExampleObject1 MyExampleObject1 { get; set; }
}