using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Payouts;

[DataContract]
public class PayoutPaymentDetails
{
    [DataMember(Order = 1), JsonProperty("paymentMethod")]
    public string PaymentMethod { get; set; }

    [DataMember(Order = 2), JsonProperty("description")]
    public string Description { get; set; }

    [DataMember(Order = 3), JsonProperty("payeeRequisite")]
    public PayeeRequisite PayeeRequisite { get; set; }

    [DataMember(Order = 4), JsonProperty("payerRequisite")]
    public PayerRequisite PayerRequisite { get; set; }
}