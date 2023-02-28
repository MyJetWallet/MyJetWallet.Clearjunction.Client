using System.Runtime.Serialization;
using MyJetWallet.ClearJunction.Converters;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.RequisitesAllocation;

[DataContract]
public class RequestAllocationResponse
{
    [DataMember(Order = 1), JsonProperty("requestReference")]
    public string RequestReference { get; set; }

    [DataMember(Order = 2), JsonProperty("clientOrder")]
    public string ClientOrder { get; set; }

    [DataMember(Order = 3), JsonProperty("orderReference")]
    public string OrderReference { get; set; }

    [DataMember(Order = 4), JsonProperty("status"), JsonConverter(typeof(AllocationStatusConverter))]
    public AllocationStatus Status { get; set; }
}