using System.Collections.Generic;
using System.Runtime.Serialization;
using MyJetWallet.ClearJunction.Models.Statements;
using Newtonsoft.Json;

namespace MyJetWallet.ClearJunction.Models.Wallet
{
    [DataContract]
    public class Wallet
    {
        [DataMember(Order = 1), JsonProperty("ownerUuid")]
        public string OwnerUuid { get; set; }
        
        [DataMember(Order = 2), JsonProperty("walletUuid")]
        public string WalletUuid { get; set; }

        [DataMember(Order = 3), JsonProperty("paymentMethods")]
        public List<PaymentMethod> PaymentMethods { get; set; }

        [DataMember(Order = 4), JsonProperty("amounts")]
        public List<Amount> Amounts { get; set; }
    }
}
