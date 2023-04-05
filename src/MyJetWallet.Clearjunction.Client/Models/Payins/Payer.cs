using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payins;

[DataContract]
public class Payer
{
    [DataMember(Order = 1), JsonProperty("address")]
    public Address Address { get; set; }
}