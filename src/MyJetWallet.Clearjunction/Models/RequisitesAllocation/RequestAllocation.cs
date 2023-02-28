using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MyJetWallet.ClearJunction.Converters;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.RequisitesAllocation
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    [DataContract]
    public class Address
    {
        [DataMember(Order = 1), JsonProperty("country")]
        public string Country { get; set; }

        [DataMember(Order = 2), JsonProperty("zip")]
        public string Zip { get; set; }

        [DataMember(Order = 3), JsonProperty("city")]
        public string City { get; set; }

        [DataMember(Order = 4), JsonProperty("street")]
        public string Street { get; set; }
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
    public class Document
    {
        [DataMember(Order = 1), JsonProperty("type")]
        public string Type { get; set; }

        [DataMember(Order = 2), JsonProperty("number")]
        public string Number { get; set; }

        [DataMember(Order = 3), JsonProperty("issuedCountryCode")]
        public string IssuedCountryCode { get; set; }

        [DataMember(Order = 4), JsonProperty("issuedBy")]
        public string IssuedBy { get; set; }

        [DataMember(Order = 5), JsonProperty("issuedDate"), JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime IssuedDate { get; set; }

        [DataMember(Order = 6), JsonProperty("expirationDate"), JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime ExpirationDate { get; set; }
    }

    [DataContract]
    public class Individual
    {
        [DataMember(Order = 1), JsonProperty("phone")]
        public string Phone { get; set; }

        [DataMember(Order = 2), JsonProperty("email")]
        public string Email { get; set; }

        [DataMember(Order = 3), JsonProperty("birthDate"), JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime BirthDate { get; set; }

        [DataMember(Order = 4), JsonProperty("birthPlace")]
        public string BirthPlace { get; set; }

        [DataMember(Order = 5), JsonProperty("address")]
        public Address Address { get; set; }

        [DataMember(Order = 6), JsonProperty("document")]
        public Document Document { get; set; }

        [DataMember(Order = 7), JsonProperty("lastName")]
        public string LastName { get; set; }

        [DataMember(Order = 8), JsonProperty("firstName")]
        public string FirstName { get; set; }

        [DataMember(Order = 9), JsonProperty("middleName")]
        public string MiddleName { get; set; }
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
    public class Registrant
    {
        [DataMember(Order = 1), JsonProperty("clientCustomerId")]
        public string ClientCustomerId { get; set; }

        [DataMember(Order = 2), JsonProperty("individual", NullValueHandling = NullValueHandling.Ignore)]
        public Individual Individual { get; set; }

        [DataMember(Order = 3), JsonProperty("corporate", NullValueHandling = NullValueHandling.Ignore)]
        public Corporate Corporate { get; set; }
    }

    [DataContract]
    public class RequestAllocation
    {
        [DataMember(Order = 1), JsonProperty("clientOrder")]
        public string ClientOrder { get; set; }

        [DataMember(Order = 2), JsonProperty("postbackUrl")]
        public string PostbackUrl { get; set; }

        [DataMember(Order = 3), JsonProperty("walletUuid")]
        public string WalletUuid { get; set; }

        [DataMember(Order = 4), JsonProperty("ibansGroup")]
        public string IbansGroup { get; set; }

        [DataMember(Order = 5), JsonProperty("ibanCountry")]
        public string IbanCountry { get; set; }

        [DataMember(Order = 6), JsonProperty("registrant")]
        public Registrant Registrant { get; set; }

        [DataMember(Order = 7), JsonProperty("customInfo")]
        public CustomInfo CustomInfo { get; set; }
    }

    [DataContract]
    public class BusinessPartner
    {
        [DataMember(Order = 1), JsonProperty("name")]
        public string Name { get; set; }

        [DataMember(Order = 2), JsonProperty("incorporationCountryCode")]
        public string IncorporationCountryCode { get; set; }

        [DataMember(Order = 3), JsonProperty("plannedTransfersQuantityMonth")]
        public int PlannedTransfersQuantityMonth { get; set; }

        [DataMember(Order = 4), JsonProperty("plannedTransfersEurVolumeMonth")]
        public int PlannedTransfersEurVolumeMonth { get; set; }

        [DataMember(Order = 5), JsonProperty("basisPartnership")]
        public string BasisPartnership { get; set; }
    }

    [DataContract]
    public class ComplianceEvaluation
    {
        [DataMember(Order = 1), JsonProperty("amlRiskLevel")]
        public string AmlRiskLevel { get; set; }

        [DataMember(Order = 2), JsonProperty("reviewPeriodicity")]
        public string ReviewPeriodicity { get; set; }

        [DataMember(Order = 3), JsonProperty("appliedLimits")]
        public string AppliedLimits { get; set; }
    }

    [DataContract]
    public class FundFlows
    {
        [DataMember(Order = 1), JsonProperty("plannedIncTransfersQuantity")]
        public int PlannedIncTransfersQuantity { get; set; }

        [DataMember(Order = 2), JsonProperty("plannedIncTransfersEurVolume")]
        public int PlannedIncTransfersEurVolume { get; set; }

        [DataMember(Order = 3), JsonProperty("plannedOutTransfersQuantity")]
        public int PlannedOutTransfersQuantity { get; set; }

        [DataMember(Order = 4), JsonProperty("plannedOutTransfersEurVolume")]
        public int PlannedOutTransfersEurVolume { get; set; }
    }

    [DataContract]
    public class OtherDetails 
    {
        [DataMember(Order = 1), JsonProperty("businessActivity")]
        public string BusinessActivity { get; set; }

        [DataMember(Order = 2), JsonProperty("relevantInformation")]
        public string RelevantInformation { get; set; }

        [DataMember(Order = 3), JsonProperty("negativeInformation")]
        public string NegativeInformation { get; set; }
    }

    [DataContract]
    public class Corporate
    {
        [DataMember(Order = 1), JsonProperty("email")]
        public string Email { get; set; }

        [DataMember(Order = 2), JsonProperty("name")]
        public string Name { get; set; }

        [DataMember(Order = 3), JsonProperty("registrationNumber")]
        public string RegistrationNumber { get; set; }

        [DataMember(Order = 4), JsonProperty("incorporationCountry")]
        public string IncorporationCountry { get; set; }

        [DataMember(Order = 5), JsonProperty("address")]
        public Address Address { get; set; }

        [DataMember(Order = 6), JsonProperty("incorporationDate"), JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime IncorporationDate { get; set; }

        [DataMember(Order = 7), JsonProperty("ultimateBeneficialOwner")]
        public List<UltimateBeneficialOwner> UltimateBeneficialOwner { get; set; }

        [DataMember(Order = 8), JsonProperty("tradingWebsite")]
        public string TradingWebsite { get; set; }

        [DataMember(Order = 9), JsonProperty("expectedTurnover")]
        public int ExpectedTurnover { get; set; }

        [DataMember(Order = 10), JsonProperty("beneficialLegalEntity")]
        public string BeneficialLegalEntity { get; set; }

        [DataMember(Order = 11), JsonProperty("otherDetails")]
        public OtherDetails OtherDetails { get; set; }

        [DataMember(Order = 12), JsonProperty("businessPartners")]
        public List<BusinessPartner> BusinessPartners { get; set; }

        [DataMember(Order = 13), JsonProperty("fundFlows")]
        public FundFlows FundFlows { get; set; }

        [DataMember(Order = 14), JsonProperty("complianceEvaluation")]
        public ComplianceEvaluation ComplianceEvaluation { get; set; }

    }

    [DataContract]
    public class UltimateBeneficialOwner
    {
        [DataMember(Order = 1), JsonProperty("lastName")]
        public string LastName { get; set; }

        [DataMember(Order = 2), JsonProperty("firstName")]
        public string FirstName { get; set; }

        [DataMember(Order = 3), JsonProperty("birthDate"), JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime BirthDate { get; set; }

        [DataMember(Order = 4), JsonProperty("ownership")]
        public int Ownership { get; set; }

        [DataMember(Order = 5), JsonProperty("document")]
        public Document Document { get; set; }

        [DataMember(Order = 6), JsonProperty("beneficialOwnerPep")]
        public bool BeneficialOwnerPep { get; set; }

        [DataMember(Order = 7), JsonProperty("beneficialOwnerPepDetails")]
        public string BeneficialOwnerPepDetails { get; set; }

        [DataMember(Order = 8), JsonProperty("usaTaxResidency")]
        public bool UsaTaxResidency { get; set; }

        [DataMember(Order = 9), JsonProperty("giinNumber")]
        public string GiinNumber { get; set; }
    }
}
