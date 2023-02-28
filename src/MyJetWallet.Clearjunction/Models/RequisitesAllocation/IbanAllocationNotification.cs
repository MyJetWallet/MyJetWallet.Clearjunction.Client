using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.RequisitesAllocation;

[DataContract]
public class IbanAllocationNotification
{
    [DataMember(Order = 1), JsonProperty("clientOrder")]
    public string ClientOrder { get; set; }

    [DataMember(Order = 2), JsonProperty("orderReference")]
    public string OrderReference { get; set; }

    [DataMember(Order = 3), JsonProperty("status")]
    public string Status { get; set; }

    [DataMember(Order = 4), JsonProperty("iban")]
    public string Iban { get; set; }

    [DataMember(Order = 5), JsonProperty("messageUuid")]
    public string MessageUuid { get; set; }

    [DataMember(Order = 6), JsonProperty("type")]
    public string Type { get; set; }
}