using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyJetWallet.ClearJunction.Models.Payins
{
    [DataContract]
    public class Address
    {
        [DataMember(Order = 1), JsonProperty("addressOneString")]
        public string AddressOneString { get; set; }

        [DataMember(Order = 2), JsonProperty("country")]
        public string Country { get; set; }
    }

    [DataContract]
    public class CustomFormat
    {
        [DataMember(Order = 1), JsonProperty("clientCustomAttributeExample")]
        public string ClientCustomAttributeExample { get; set; }
    }

    [DataContract]
    public class CustomInfo
    {
        [DataMember(Order = 1), JsonProperty("MyExampleParam1")]
        public string MyExampleParam1 { get; set; }

        [DataMember(Order = 2), JsonProperty("MyExampleObject1")]
        public MyExampleObject1 MyExampleObject1 { get; set; }
    }

    [DataContract]
    public class Message
    {
        [DataMember(Order = 1), JsonProperty("code")]
        public string Code { get; set; }

        [DataMember(Order = 2), JsonProperty("message")]
        public string MessageItem { get; set; }

        [DataMember(Order = 3), JsonProperty("details")]
        public string Details { get; set; }
    }

    [DataContract]
    public class MyExampleObject1
    {
        [DataMember(Order = 1), JsonProperty("MyExampleParam2")]
        public string MyExampleParam2 { get; set; }

        [DataMember(Order = 2), JsonProperty("MyExampleParam3")]
        public string MyExampleParam3 { get; set; }
    }

    [DataContract]
    public class Payee
    {
        [DataMember(Order = 1), JsonProperty("walletUuid")]
        public string WalletUuid { get; set; }

        [DataMember(Order = 2), JsonProperty("clientCustomerId")]
        public string ClientCustomerId { get; set; }
    }

    [DataContract]
    public class Payer
    {
        [DataMember(Order = 1), JsonProperty("address")]
        public Address Address { get; set; }
    }

    [DataContract]
    public class PayinNotification
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

        [DataMember(Order = 19), JsonProperty("payee")]
        public Payee Payee { get; set; }

        [DataMember(Order = 20), JsonProperty("paymentDetails")]
        public SwiftPaymentDetails PaymentDetails { get; set; }

        [DataMember(Order = 21), JsonProperty("messageUuid")]
        public string MessageUuid { get; set; }

        [DataMember(Order = 22), JsonProperty("type")]
        public string Type { get; set; }
    }

    [DataContract]
    public class SubStatuses
    {
        [DataMember(Order = 1), JsonProperty("operStatus")]
        public string OperStatus { get; set; }

        [DataMember(Order = 2), JsonProperty("complianceStatus")]
        public string ComplianceStatus { get; set; }
    }

}
