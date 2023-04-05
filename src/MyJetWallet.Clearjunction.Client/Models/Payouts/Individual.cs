using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class Individual
{
    [DataMember(Order = 1), JsonProperty("phone")]
    public string Phone { get; set; }

    [DataMember(Order = 2), JsonProperty("email")]
    public string Email { get; set; }

    [DataMember(Order = 3), JsonProperty("birthDate")]
    public string BirthDate { get; set; }

    [DataMember(Order = 4), JsonProperty("birthPlace")]
    public string BirthPlace { get; set; }

    [DataMember(Order = 5), JsonProperty("address")]
    public Address Address { get; set; }

    [DataMember(Order = 6), JsonProperty("document")]
    public Document Document { get; set; }

    [DataMember(Order = 7), JsonProperty("lastName")]
    public string LastName { get; set; }

    [DataMember(Order = 8), JsonProperty("firstName")]
    public string FirstName { get; set; }

    [DataMember(Order = 9), JsonProperty("middleName")]
    public string MiddleName { get; set; }
}