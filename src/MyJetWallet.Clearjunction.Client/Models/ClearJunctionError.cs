using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models;

public class ClearJunctionError
{
    [JsonProperty("errors")]
    public ClearJunctionErrorItem[] Errors { get; set; }
}