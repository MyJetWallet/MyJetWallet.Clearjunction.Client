using System.Runtime.Serialization;
using MyJetWallet.ClearJunction.Converters;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class ReturnSubStatuses
{
    [DataMember(Order = 1), JsonProperty("operStatus")]
    [JsonConverter(typeof(PayoutReturnNotificationOperStatusConverter))]
    public ReturnSubStatusesOperStatus SubStatusesOperStatus { get; set; }

    [DataMember(Order = 2), JsonProperty("complianceStatus")]
    [JsonConverter(typeof(PayoutNotificationComplianceStatusConverter))]
    public SubStatusesComplianceStatus SubStatusesComplianceStatus { get; set; }
}