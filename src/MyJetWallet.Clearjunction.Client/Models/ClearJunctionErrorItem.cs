using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models;

[DataContract]
public class ClearJunctionErrorItem
{
    [DataMember(Order = 1), JsonProperty("code")]
    public int Code { get; set; }

    [DataMember(Order = 2),JsonProperty("message")]
    public string Message { get; set; }

    [DataMember(Order = 3),JsonProperty("details")]
    public string Details { get; set; }
}