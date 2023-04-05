using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class IntermediaryInstitution
{
    [DataMember(Order = 1), JsonProperty("bankCode")]
    public string BankCode { get; set; }

    [DataMember(Order = 2), JsonProperty("bankName")]
    public string BankName { get; set; }

    [DataMember(Order = 3), JsonProperty("bankCountry")]
    public string BankCountry { get; set; }

    [DataMember(Order = 4), JsonProperty("bankOneStringAddress")]
    public string BankOneStringAddress { get; set; }
}