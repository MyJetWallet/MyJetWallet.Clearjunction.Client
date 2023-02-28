using System.Collections.Generic;
using MyJetWallet.ClearJunction.Base;
using MyJetWallet.ClearJunction.Models.RequisitesAllocation;

namespace MyJetWallet.ClearJunction.Converters
{
    public class AllocationStatusConverter : BaseConverter<AllocationStatus>
    {
        public AllocationStatusConverter() : this(true)
        {
        }

        public AllocationStatusConverter(bool quotes) : base(quotes)
        {
        }

        protected override List<KeyValuePair<AllocationStatus, string>> Mapping => new()
        {
            new KeyValuePair<AllocationStatus, string>(AllocationStatus.Accepted, "accepted"),
            new KeyValuePair<AllocationStatus, string>(AllocationStatus.Allocated, "allocated"),
            new KeyValuePair<AllocationStatus, string>(AllocationStatus.Declined, "declined"),
            new KeyValuePair<AllocationStatus, string>(AllocationStatus.Pending, "pending"),
        };
    }

}
