using System.Collections.Generic;
using MyJetWallet.ClearJunction.Base;
using MyJetWallet.ClearJunction.Models.Payins;
using MyJetWallet.ClearJunction.Models.Payouts;

namespace MyJetWallet.ClearJunction.Converters;

public class PayoutNotificationOperStatusConverter : BaseConverter<SubStatusesOperStatus>
{
    public PayoutNotificationOperStatusConverter() : this(true)
    {
    }

    public PayoutNotificationOperStatusConverter(bool quotes) : base(quotes)
    {
    }

    protected override List<KeyValuePair<SubStatusesOperStatus, string>> Mapping => new()
    {
        new KeyValuePair<SubStatusesOperStatus, string>(SubStatusesOperStatus.Created, "created"),
        new KeyValuePair<SubStatusesOperStatus, string>(SubStatusesOperStatus.Canceled, "canceled"),
        new KeyValuePair<SubStatusesOperStatus, string>(SubStatusesOperStatus.Pending, "pending"),
        new KeyValuePair<SubStatusesOperStatus, string>(SubStatusesOperStatus.Settled, "settled"),
        new KeyValuePair<SubStatusesOperStatus, string>(SubStatusesOperStatus.Declined, "declined"),
    };
}