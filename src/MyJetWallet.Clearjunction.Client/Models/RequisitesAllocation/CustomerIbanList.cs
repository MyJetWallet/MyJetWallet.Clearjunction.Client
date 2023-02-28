using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.RequisitesAllocation;

[DataContract]
public class CustomerIbanList
{
    [DataMember(Order = 1),JsonProperty("requestReference")]
    public string RequestReference { get; set; }

    [DataMember(Order = 2), JsonProperty("clientCustomerId")]
    public string ClientCustomerId { get; set; }

    [DataMember(Order = 3), JsonProperty("ibans")]
    public List<string> Ibans { get; set; }
}