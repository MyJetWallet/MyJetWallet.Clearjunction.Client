using System.Collections.Generic;
using MyJetWallet.ClearJunction.Base;
using MyJetWallet.ClearJunction.Models.Payins;
using MyJetWallet.ClearJunction.Models.Payouts;

namespace MyJetWallet.ClearJunction.Converters;

public class PayoutReturnNotificationOperStatusConverter : BaseConverter<ReturnSubStatusesOperStatus>
{
    public PayoutReturnNotificationOperStatusConverter() : this(true)
    {
    }

    public PayoutReturnNotificationOperStatusConverter(bool quotes) : base(quotes)
    {
    }

    protected override List<KeyValuePair<ReturnSubStatusesOperStatus, string>> Mapping => new()
    {
        new KeyValuePair<ReturnSubStatusesOperStatus, string>(ReturnSubStatusesOperStatus.Captured, "captured"),
        new KeyValuePair<ReturnSubStatusesOperStatus, string>(ReturnSubStatusesOperStatus.Settled, "settled"),
    };
}