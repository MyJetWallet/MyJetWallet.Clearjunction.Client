using System.Collections.Generic;
using System.Runtime.Serialization;
using MyJetWallet.ClearJunction.Models.Reports.Values;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Reports;

[DataContract]
public class ReportItem
{
    [JsonProperty("clientOrder")]
    [DataMember(Order = 1)]
    public string ClientOrder { get; set; }

    [JsonProperty("orderReference")]
    [DataMember(Order = 2)]
    public string OrderReference { get; set; }

    [JsonProperty("operTimestamp")]
    [DataMember(Order = 3)]
    public string OperTimestamp { get; set; }

    [JsonProperty("messages")]
    [DataMember(Order = 4)]
    public List<Message> Messages { get; set; }

    [JsonProperty("currency")]
    [DataMember(Order = 5)]
    public string Currency { get; set; }

    [JsonProperty("amount")]
    [DataMember(Order = 6)]
    public decimal Amount { get; set; }

    [JsonProperty("operationCurrency")]
    [DataMember(Order = 7)]
    public string OperationCurrency { get; set; }

    [JsonProperty("operationAmount")]
    [DataMember(Order = 8)]
    public decimal OperationAmount { get; set; }

    [JsonProperty("walletUuid")]
    [DataMember(Order = 9)]
    public string WalletUuid { get; set; }

    [JsonProperty("transactionType")]
    [DataMember(Order = 10)]
    public TransactionType TransactionType { get; set; }

    [JsonProperty("operStatus")]
    [DataMember(Order = 11)]
    public OperStatus OperStatus { get; set; }
}