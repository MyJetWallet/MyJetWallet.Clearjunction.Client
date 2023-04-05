using System.Collections.Generic;
using MyJetWallet.ClearJunction.Base;
using MyJetWallet.ClearJunction.Models.Payins;
using MyJetWallet.ClearJunction.Models.Payouts;

namespace MyJetWallet.ClearJunction.Converters;

public class PayoutReturnNotificationStatusConverter : BaseConverter<PayoutReturnNotificationStatus>
{
    public PayoutReturnNotificationStatusConverter() : this(true)
    {
    }

    public PayoutReturnNotificationStatusConverter(bool quotes) : base(quotes)
    {
    }

    protected override List<KeyValuePair<PayoutReturnNotificationStatus, string>> Mapping => new()
    {
        new KeyValuePair<PayoutReturnNotificationStatus, string>(PayoutReturnNotificationStatus.Captured, "captured"),
        new KeyValuePair<PayoutReturnNotificationStatus, string>(PayoutReturnNotificationStatus.Settled, "settled"),
    };
}