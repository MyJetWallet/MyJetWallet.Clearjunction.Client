using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class PayerRequisite
{
    [DataMember(Order = 1), JsonProperty("iban")]
    public string Iban { get; set; }

    [DataMember(Order = 2), JsonProperty("bankSwiftCode")]
    public string BankSwiftCode { get; set; }
    
    [DataMember(Order = 3), JsonProperty("bankAccountNumber")]
    public string BankAccountNumber { get; set; }
    
    [DataMember(Order = 4), JsonProperty("bankCountry")]
    public string BankCountry { get; set; }
    
    [DataMember(Order = 5), JsonProperty("bankOneStringAddress")]
    public string BankOneStringAddress { get; set; }
    
    [DataMember(Order = 6), JsonProperty("intermediaryInstitution")]
    public IntermediaryInstitution IntermediaryInstitution { get; set; }
    
    [DataMember(Order = 7), JsonProperty("name")]
    public string PayerName { get; set; }
}