using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Reports;

[DataContract]
public class GetReportRequest
{
    [DataMember(Order = 1), JsonProperty("walletUuid")]
    public string WalletUuid { get; set; }

    [DataMember(Order = 2), JsonProperty("timestampFrom")]
    public string DateFrom { get; set; }

    [DataMember(Order = 3), JsonProperty("timestampTo")]
    public string DateTo { get; set; }
}