using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Statements
{
    [DataContract]
    public class Statement
    {
        [DataMember(Order = 1), JsonProperty("requestReference")]
        public string RequestReference { get; set; }

        [DataMember(Order = 2), JsonProperty("statements")]
        public IReadOnlyCollection<StatementItem> Statements { get; set; }

    }
}
