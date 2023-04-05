using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class SepaInstantPayout
{
    [DataMember(Order = 1), JsonProperty("clientOrder")]
    public string ClientOrder { get; set; }

    [DataMember(Order = 2), JsonProperty("currency")]
    public string Currency { get; set; }

    [DataMember(Order = 3), JsonProperty("amount")]
    public decimal Amount { get; set; }

    [DataMember(Order = 4), JsonProperty("description")]
    public string Description { get; set; }

    [DataMember(Order = 5), JsonProperty("postbackUrl")]
    public string PostbackUrl { get; set; }

    [DataMember(Order = 6), JsonProperty("customInfo", NullValueHandling = NullValueHandling.Ignore)]
    public CustomInfo CustomInfo { get; set; }

    [DataMember(Order = 7), JsonProperty("payer")]
    public Payer Payer { get; set; }

    [DataMember(Order = 8), JsonProperty("payee")]
    public Payee Payee { get; set; }

    [DataMember(Order = 9), JsonProperty("payeeRequisite")]
    public PayeeRequisite PayeeRequisite { get; set; }

    [DataMember(Order = 10), JsonProperty("payerRequisite")]
    public PayerRequisite PayerRequisite { get; set; }
}