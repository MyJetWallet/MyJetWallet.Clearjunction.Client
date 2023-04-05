using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payins;

[DataContract]
public class Address
{
    [DataMember(Order = 1), JsonProperty("addressOneString")]
    public string AddressOneString { get; set; }

    [DataMember(Order = 2), JsonProperty("country")]
    public string Country { get; set; }
}