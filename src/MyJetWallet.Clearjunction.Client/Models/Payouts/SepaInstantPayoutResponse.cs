using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class SepaInstantPayoutResponse
{
    [DataMember(Order = 1), JsonProperty("requestReference")]
    public string RequestReference { get; set; }

    [DataMember(Order = 2), JsonProperty("clientOrder")]
    public string ClientOrder { get; set; }

    [DataMember(Order = 3), JsonProperty("orderReference")]
    public string OrderReference { get; set; }

    [DataMember(Order = 4), JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }

    [DataMember(Order = 5), JsonProperty("messages")]
    public List<Message> Messages { get; set; }

    [DataMember(Order = 6), JsonProperty("customFormat")]
    public CustomFormat CustomFormat { get; set; }

    [DataMember(Order = 7), JsonProperty("status")]
    public string Status { get; set; }

    [DataMember(Order = 8), JsonProperty("subStatuses")]
    public SubStatuses SubStatuses { get; set; }
}