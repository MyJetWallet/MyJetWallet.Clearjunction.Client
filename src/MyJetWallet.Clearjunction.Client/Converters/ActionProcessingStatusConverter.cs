using System.Collections.Generic;
using MyJetWallet.ClearJunction.Base;
using MyJetWallet.ClearJunction.Models.Payouts;

namespace MyJetWallet.ClearJunction.Converters;

public class ActionProcessingStatusConverter : BaseConverter<ActionProcessingStatus>
{
    public ActionProcessingStatusConverter() : this(true)
    {
    }

    public ActionProcessingStatusConverter(bool quotes) : base(quotes)
    {
    }

    protected override List<KeyValuePair<ActionProcessingStatus, string>> Mapping => new()
    {
        new KeyValuePair<ActionProcessingStatus, string>(ActionProcessingStatus.Success, "success"),
        new KeyValuePair<ActionProcessingStatus, string>(ActionProcessingStatus.Declined, "declined"),
    };
}