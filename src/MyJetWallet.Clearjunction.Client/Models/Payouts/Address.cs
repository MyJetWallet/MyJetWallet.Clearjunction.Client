using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class Address
{
    [DataMember(Order = 1), JsonProperty("country")]
    public string Country { get; set; }

    [DataMember(Order = 2), JsonProperty("zip")]
    public string Zip { get; set; }

    [DataMember(Order = 3), JsonProperty("city")]
    public string City { get; set; }

    [DataMember(Order = 4), JsonProperty("street")]
    public string Street { get; set; }
}