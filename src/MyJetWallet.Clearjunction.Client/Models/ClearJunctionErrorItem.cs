using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models;

public class ClearJunctionErrorItem
{
    [JsonProperty("code")]
    public int Code { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("details")]
    public string Details { get; set; }

}