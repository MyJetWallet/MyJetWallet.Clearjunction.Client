using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class Document
{
    [DataMember(Order = 1), JsonProperty("type")]
    public string Type { get; set; }

    [DataMember(Order = 2), JsonProperty("number")]
    public string Number { get; set; }

    [DataMember(Order = 3), JsonProperty("issuedCountryCode")]
    public string IssuedCountryCode { get; set; }

    [DataMember(Order = 4), JsonProperty("issuedBy")]
    public string IssuedBy { get; set; }

    [DataMember(Order = 5), JsonProperty("issuedDate")]
    public string IssuedDate { get; set; }

    [DataMember(Order = 6), JsonProperty("expirationDate")]
    public string ExpirationDate { get; set; }
}