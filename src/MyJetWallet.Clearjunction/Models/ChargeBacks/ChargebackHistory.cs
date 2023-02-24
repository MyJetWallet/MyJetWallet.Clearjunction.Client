using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.ChargeBacks
{
    [DataContract]
    public class ChargebackHistory
    {
        [DataMember(Order = 1), JsonProperty("type")]
        public string Type { get; set; }

        //[DataMember(Order = 2), JsonProperty("chargebackAmount")]
        //public CircleAmount ChargebackAmount { get; set; }

        //[DataMember(Order = 3), JsonProperty("fee")]
        //public CircleAmount Fee { get; set; }

        [DataMember(Order = 4), JsonProperty("description")]
        public string Description { get; set; }

        [DataMember(Order = 5), JsonProperty("settlementId")]
        public string SettlementId { get; set; }

        [DataMember(Order = 6), JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }

    }
}
