using System.Collections.Generic;
using MyJetWallet.ClearJunction.Base;
using MyJetWallet.ClearJunction.Models.Payins;
using MyJetWallet.ClearJunction.Models.Payouts;

namespace MyJetWallet.ClearJunction.Converters;

public class PayoutNotificationComplianceStatusConverter : BaseConverter<SubStatusesComplianceStatus>
{
    public PayoutNotificationComplianceStatusConverter() : this(true)
    {
    }

    public PayoutNotificationComplianceStatusConverter(bool quotes) : base(quotes)
    {
    }

    protected override List<KeyValuePair<SubStatusesComplianceStatus, string>> Mapping => new()
    {
        new KeyValuePair<SubStatusesComplianceStatus, string>(SubStatusesComplianceStatus.Created, "created"),
        new KeyValuePair<SubStatusesComplianceStatus, string>(SubStatusesComplianceStatus.Clean, "clean"),
        new KeyValuePair<SubStatusesComplianceStatus, string>(SubStatusesComplianceStatus.Pending, "pending"),
        new KeyValuePair<SubStatusesComplianceStatus, string>(SubStatusesComplianceStatus.Approved, "approved"),
        new KeyValuePair<SubStatusesComplianceStatus, string>(SubStatusesComplianceStatus.Blocked, "blocked"),
    };
}