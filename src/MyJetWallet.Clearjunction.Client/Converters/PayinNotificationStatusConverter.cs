using System.Collections.Generic;
using MyJetWallet.ClearJunction.Base;
using MyJetWallet.ClearJunction.Models.Payins;

namespace MyJetWallet.ClearJunction.Converters;

public class PayinNotificationStatusConverter : BaseConverter<PayinNotificationStatus>
{
    public PayinNotificationStatusConverter() : this(true)
    {
    }

    public PayinNotificationStatusConverter(bool quotes) : base(quotes)
    {
    }

    protected override List<KeyValuePair<PayinNotificationStatus, string>> Mapping => new()
    {
        new KeyValuePair<PayinNotificationStatus, string>(PayinNotificationStatus.Created, "created"),
        new KeyValuePair<PayinNotificationStatus, string>(PayinNotificationStatus.Expired, "expired"),
        new KeyValuePair<PayinNotificationStatus, string>(PayinNotificationStatus.Canceled, "canceled"),
        new KeyValuePair<PayinNotificationStatus, string>(PayinNotificationStatus.Rejected, "rejected"),
        new KeyValuePair<PayinNotificationStatus, string>(PayinNotificationStatus.Returned, "returned"),
        new KeyValuePair<PayinNotificationStatus, string>(PayinNotificationStatus.Pending, "pending"),
        new KeyValuePair<PayinNotificationStatus, string>(PayinNotificationStatus.Authorized, "authorized"),
        new KeyValuePair<PayinNotificationStatus, string>(PayinNotificationStatus.Captured, "captured"),
        new KeyValuePair<PayinNotificationStatus, string>(PayinNotificationStatus.Settled, "settled"),
        new KeyValuePair<PayinNotificationStatus, string>(PayinNotificationStatus.Declined, "declined"),

    };
}