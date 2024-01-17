using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Reports;

[DataContract]
public class Message
{
    [DataMember(Order = 1), JsonProperty("code")]
    public string Code { get; set; }

    [DataMember(Order = 2), JsonProperty("message")]
    public string MessageItem { get; set; }

    [DataMember(Order = 3), JsonProperty("details")]
    public string Details { get; set; }
}