using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payins;

[DataContract]
public class SubStatuses
{
    [DataMember(Order = 1), JsonProperty("operStatus")]
    public string OperStatus { get; set; }

    [DataMember(Order = 2), JsonProperty("complianceStatus")]
    public string ComplianceStatus { get; set; }
}