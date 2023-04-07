using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class PayeeRequisite
{
    [DataMember(Order = 1), JsonProperty("iban")]
    public string Iban { get; set; }

    [DataMember(Order = 2), JsonProperty("bankSwiftCode")]
    public string BankSwiftCode { get; set; }
    
    [DataMember(Order = 3), JsonProperty("bankAccountNumber", NullValueHandling = NullValueHandling.Ignore)]
    public string BankAccountNumber { get; set; }
    
    [DataMember(Order = 4), JsonProperty("bankCountry", NullValueHandling = NullValueHandling.Ignore)]
    public string BankCountry { get; set; }
    
    [DataMember(Order = 5), JsonProperty("bankOneStringAddress", NullValueHandling = NullValueHandling.Ignore)]
    public string BankOneStringAddress { get; set; }
    
    [DataMember(Order = 6), JsonProperty("intermediaryInstitution", NullValueHandling = NullValueHandling.Ignore)]
    public IntermediaryInstitution IntermediaryInstitution { get; set; }
    
    [DataMember(Order = 7), JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string PayeeName { get; set; }
}