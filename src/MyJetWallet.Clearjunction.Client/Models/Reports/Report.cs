using System.Collections.Generic;
using System.Runtime.Serialization;
using MyJetWallet.ClearJunction.Models.Statements;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Reports
{
    [DataContract]
    public class Report
    {
        [DataMember(Order = 1), JsonProperty("requestReference")]
        public string RequestReference { get; set; }

        [DataMember(Order = 2), JsonProperty("report")]
        public IReadOnlyCollection<ReportItem> Reports { get; set; }
    }
}
