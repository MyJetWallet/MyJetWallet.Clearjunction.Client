using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.RequisitesAllocation;

[DataContract]
public class IbanInformation
{
    [DataMember(Order = 1), JsonProperty("requestReference")]
    public string RequestReference { get; set; }

    [DataMember(Order = 2), JsonProperty("walletUuid")]
    public string WalletUuid { get; set; }

    [DataMember(Order = 3), JsonProperty("registrant")]
    public Registrant Registrant { get; set; }

    [DataMember(Order = 4), JsonProperty("ibanCreatedAt")]
    public DateTime IbanCreatedAt { get; set; }
}