using System.Runtime.Serialization;
using MyJetWallet.ClearJunction.Converters;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

public class ActionResult
{
    [DataMember(Order = 1), JsonProperty("orderReference", NullValueHandling = NullValueHandling.Ignore)]
    public string OrderReference { get; set; }
 
    [DataMember(Order = 2), JsonProperty("actionProcessingStatus", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(ActionProcessingStatusConverter))]
    public ActionProcessingStatus ActionProcessingStatus { get; set; }

    [DataMember(Order = 3), JsonProperty("messages", NullValueHandling = NullValueHandling.Ignore)]
    public Message[] Messages { get; set; }
}