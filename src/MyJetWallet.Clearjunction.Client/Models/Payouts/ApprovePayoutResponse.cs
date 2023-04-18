using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class ApprovePayoutResponse
{
    [DataMember(Order = 1), JsonProperty("requestReference", NullValueHandling = NullValueHandling.Ignore)]
    public string RequestReference { get; set; }

    [DataMember(Order = 2), JsonProperty("actionResult", NullValueHandling = NullValueHandling.Ignore)]
    public ActionResult[] ActionResult { get; set; }

}