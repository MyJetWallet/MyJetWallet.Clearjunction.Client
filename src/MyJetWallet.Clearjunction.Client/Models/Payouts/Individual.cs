using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class Individual
{
    [DataMember(Order = 1), JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
    public string Phone { get; set; }

    [DataMember(Order = 2), JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
    public string Email { get; set; }

    [DataMember(Order = 3), JsonProperty("birthDate", NullValueHandling = NullValueHandling.Ignore)]
    public string BirthDate { get; set; }

    [DataMember(Order = 4), JsonProperty("birthPlace", NullValueHandling = NullValueHandling.Ignore)]
    public string BirthPlace { get; set; }

    [DataMember(Order = 5), JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
    public Address Address { get; set; }

    [DataMember(Order = 6), JsonProperty("document", NullValueHandling = NullValueHandling.Ignore)]
    public Document Document { get; set; }

    [DataMember(Order = 7), JsonProperty("lastName")]
    public string LastName { get; set; }

    [DataMember(Order = 8), JsonProperty("firstName")]
    public string FirstName { get; set; }

    [DataMember(Order = 9), JsonProperty("middleName", NullValueHandling = NullValueHandling.Ignore)]
    public string MiddleName { get; set; }
}