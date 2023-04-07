using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.SepaIban;

[DataContract]
public class SepaIban
{
    [JsonProperty("requestReference")]
    public string RequestReference { get; set; }

    [JsonProperty("bankSwiftCode")]
    public string BankSwiftCode { get; set; }

    [JsonProperty("bankName")]
    public string BankName { get; set; }

    [JsonProperty("sepaReachable")]
    public bool SepaReachable { get; set; }

    [JsonProperty("sepaInstReachable")]
    public bool SepaInstReachable { get; set; }
}