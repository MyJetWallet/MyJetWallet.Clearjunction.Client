using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Statements;

[DataContract]
public class StatementTransaction
{
    [DataMember(Order = 1), JsonProperty("clientOrder")]
    public string ClientOrder { get; set; }

    [DataMember(Order = 2), JsonProperty("orderReference")]
    public string OrderReference { get; set; }

    [DataMember(Order = 3), JsonProperty("valuedAt")]
    public DateTime? ValuedAt { get; set; }

    [DataMember(Order = 4), JsonProperty("amount")]
    public decimal Amount { get; set; }

    [DataMember(Order = 5), JsonProperty("feeAmount")]
    public decimal FeeAmount { get; set; }

    //[DataMember(Order = 6), JsonProperty("paymentDetails")]
    //public string PaymentDetails { get; set; }


}