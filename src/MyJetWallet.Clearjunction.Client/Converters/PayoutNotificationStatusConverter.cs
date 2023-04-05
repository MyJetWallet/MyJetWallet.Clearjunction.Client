using System.Collections.Generic;
using MyJetWallet.ClearJunction.Base;
using MyJetWallet.ClearJunction.Models.Payins;
using MyJetWallet.ClearJunction.Models.Payouts;

namespace MyJetWallet.ClearJunction.Converters;

public class PayoutNotificationStatusConverter : BaseConverter<PayoutNotificationStatus>
{
    public PayoutNotificationStatusConverter() : this(true)
    {
    }

    public PayoutNotificationStatusConverter(bool quotes) : base(quotes)
    {
    }

    protected override List<KeyValuePair<PayoutNotificationStatus, string>> Mapping => new()
    {
        new KeyValuePair<PayoutNotificationStatus, string>(PayoutNotificationStatus.Created, "created"),
        new KeyValuePair<PayoutNotificationStatus, string>(PayoutNotificationStatus.Canceled, "canceled"),
        new KeyValuePair<PayoutNotificationStatus, string>(PayoutNotificationStatus.Pending, "pending"),
        new KeyValuePair<PayoutNotificationStatus, string>(PayoutNotificationStatus.Settled, "settled"),
        new KeyValuePair<PayoutNotificationStatus, string>(PayoutNotificationStatus.Declined, "declined"),
    };
}