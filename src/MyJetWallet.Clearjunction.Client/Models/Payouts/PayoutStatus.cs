using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class PayoutStatus
{
    [DataMember(Order = 1), JsonProperty("clientOrder")]
    public string ClientOrder { get; set; }

    [DataMember(Order = 2), JsonProperty("orderReference")]
    public string OrderReference { get; set; }

    [DataMember(Order = 3), JsonProperty("operTimestamp")]
    public DateTime OperTimestamp { get; set; }

    [DataMember(Order = 4), JsonProperty("messages")]
    public List<Message> Messages { get; set; }

    [DataMember(Order = 5), JsonProperty("currency")]
    public string Currency { get; set; }

    [DataMember(Order = 6), JsonProperty("amount")]
    public double Amount { get; set; }

    [DataMember(Order = 7), JsonProperty("operationCurrency")]
    public string OperationCurrency { get; set; }

    [DataMember(Order = 8), JsonProperty("operationAmount")]
    public double OperationAmount { get; set; }

    [DataMember(Order = 9), JsonProperty("productName")]
    public string ProductName { get; set; }

    [DataMember(Order = 10), JsonProperty("siteAddress")]
    public string SiteAddress { get; set; }

    [DataMember(Order = 11), JsonProperty("label")]
    public string Label { get; set; }

    [DataMember(Order = 12), JsonProperty("customInfo")]
    public CustomInfo CustomInfo { get; set; }

    [DataMember(Order = 13), JsonProperty("customFormat")]
    public CustomFormat CustomFormat { get; set; }

    [DataMember(Order = 14), JsonProperty("valuedAt")]
    public object ValuedAt { get; set; }

    [DataMember(Order = 15), JsonProperty("status")]
    public string Status { get; set; }

    [DataMember(Order = 16), JsonProperty("transactionType")]
    public string TransactionType { get; set; }

    [DataMember(Order = 17), JsonProperty("subStatuses")]
    public SubStatuses SubStatuses { get; set; }

    [DataMember(Order = 18), JsonProperty("payer")]
    public Payer Payer { get; set; }

    [DataMember(Order = 19), JsonProperty("paymentDetails")]
    public PaymentDetails PaymentDetails { get; set; }

    [DataMember(Order = 20), JsonProperty("requestReference")]
    public string RequestReference { get; set; }
}