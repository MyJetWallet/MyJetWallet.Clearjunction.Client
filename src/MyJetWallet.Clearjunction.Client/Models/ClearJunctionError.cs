using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models;

[DataContract]
public class ClearJunctionError
{
    [DataMember(Order = 1),JsonProperty("errors")]
    public ClearJunctionErrorItem[] Errors { get; set; }
}