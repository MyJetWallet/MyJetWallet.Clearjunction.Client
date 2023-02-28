using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Statements;

[DataContract]
public class GetStatementRequest
{
    [DataMember(Order = 1), JsonProperty("walletUuid")]
    public string WalletUuid { get; set; }

    [DataMember(Order = 2), JsonProperty("dateFrom")]
    public string DateFrom { get; set; }

    [DataMember(Order = 3), JsonProperty("dateTo")]
    public string DateTo { get; set; }
}