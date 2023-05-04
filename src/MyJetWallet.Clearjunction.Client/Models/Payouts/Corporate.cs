using System;
using System.Runtime.Serialization;
using MyJetWallet.ClearJunction.Converters;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class Corporate
{
    [DataMember(Order = 1), JsonProperty("email")]
    public string Email { get; set; }

    [DataMember(Order = 2), JsonProperty("name")]
    public string Name { get; set; }

    [DataMember(Order = 3), JsonProperty("registrationNumber")]
    public string RegistrationNumber { get; set; }

    [DataMember(Order = 4), JsonProperty("incorporationCountry")]
    public string IncorporationCountry { get; set; }

    [DataMember(Order = 5), JsonProperty("address")]
    public Address Address { get; set; }

    [DataMember(Order = 6), JsonProperty("incorporationDate"), JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime IncorporationDate { get; set; }
}