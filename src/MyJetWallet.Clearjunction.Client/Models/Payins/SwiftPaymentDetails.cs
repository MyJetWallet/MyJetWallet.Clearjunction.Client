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
    public class IntermediaryInstitution
    {
        [DataMember(Order = 1), JsonProperty("bankCode")]
        public string BankCode { get; set; }

        [DataMember(Order = 2), JsonProperty("bankName")]
        public string BankName { get; set; }

        [DataMember(Order = 3), JsonProperty("bankCountry")]
        public string BankCountry { get; set; }

        [DataMember(Order = 4), JsonProperty("bankOneStringAddress")]
        public string BankOneStringAddress { get; set; }
    }

    [DataContract]
    public class PayeeRequisite
    {
        [DataMember(Order = 1), JsonProperty("bankAccountNumber")]
        public string BankAccountNumber { get; set; }

        [DataMember(Order = 2), JsonProperty("bankName")]
        public string BankName { get; set; }

        [DataMember(Order = 3), JsonProperty("bankSwiftCode")]
        public string BankSwiftCode { get; set; }

        [DataMember(Order = 4), JsonProperty("bankCountry")]
        public string BankCountry { get; set; }

        [DataMember(Order = 5), JsonProperty("bankOneStringAddress")]
        public string BankOneStringAddress { get; set; }

        [DataMember(Order = 6), JsonProperty("intermediaryInstitution")]
        public IntermediaryInstitution IntermediaryInstitution { get; set; }

        [DataMember(Order = 7), JsonProperty("name")]
        public string Name { get; set; }
    }

    [DataContract]
    public class PayerRequisite
    {
        [DataMember(Order = 1), JsonProperty("bankAccountNumber")]
        public string BankAccountNumber { get; set; }

        [DataMember(Order = 2), JsonProperty("bankName")]
        public string BankName { get; set; }

        [DataMember(Order = 3), JsonProperty("bankSwiftCode")]
        public string BankSwiftCode { get; set; }

        [DataMember(Order = 4), JsonProperty("bankCountry")]
        public string BankCountry { get; set; }

        [DataMember(Order = 5), JsonProperty("bankOneStringAddress")]
        public string BankOneStringAddress { get; set; }

        [DataMember(Order = 6), JsonProperty("intermediaryInstitution")]
        public IntermediaryInstitution IntermediaryInstitution { get; set; }

        [DataMember(Order = 7), JsonProperty("name")]
        public string Name { get; set; }
    }

    [DataContract]
    public class SwiftPaymentDetails
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


}
