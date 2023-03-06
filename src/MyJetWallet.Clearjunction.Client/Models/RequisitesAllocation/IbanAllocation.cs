using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MyJetWallet.ClearJunction.Converters;

namespace MyJetWallet.ClearJunction.Models.RequisitesAllocation
{
    [DataContract]
    public class IbanAllocation
    {
        [DataMember(Order = 1), JsonProperty("clientOrder")]
        public string ClientOrder { get; set; }

        [DataMember(Order = 2), JsonProperty("orderReference")]
        public string OrderReference { get; set; }

        [DataMember(Order = 3), JsonProperty("status")]
        [JsonConverter(typeof (AllocationStatusConverter))]
        public AllocationStatus Status { get; set; }

        [DataMember(Order = 4), JsonProperty("messages")]
        public List<Message> Messages { get; set; }

        [DataMember(Order = 5), JsonProperty("iban")]
        public string Iban { get; set; }

        [DataMember(Order = 6), JsonProperty("requestReference")]
        public string RequestReference { get; set; }
    }
}
