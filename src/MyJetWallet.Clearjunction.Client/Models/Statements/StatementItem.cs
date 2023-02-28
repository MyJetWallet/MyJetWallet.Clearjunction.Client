using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Statements;

[DataContract]
public class StatementItem
{
    [DataMember(Order = 1), JsonProperty("currency")]
    public string Currency { get; set; }

    [DataMember(Order = 2), JsonProperty("balanceIn")]
    public decimal BalanceIn { get; set; }

    [DataMember(Order = 3), JsonProperty("countIn")]
    public decimal CountIn { get; set; }

    [DataMember(Order = 4), JsonProperty("turnIn")]
    public decimal TurnIn { get; set; }

    [DataMember(Order = 5), JsonProperty("countOut")]
    public decimal CountOut { get; set; }

    [DataMember(Order = 6), JsonProperty("turnOut")]
    public decimal TurnOut { get; set; }

    [DataMember(Order = 7), JsonProperty("balanceOut")]
    public decimal BalanceOut { get; set; }

    [DataMember(Order = 8), JsonProperty("transactions")]
    public IReadOnlyCollection<StatementTransaction> Transactions { get; set; }

}