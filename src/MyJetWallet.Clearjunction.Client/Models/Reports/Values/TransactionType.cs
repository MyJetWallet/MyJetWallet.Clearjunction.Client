namespace MyJetWallet.ClearJunction.Models.Reports.Values;

public enum TransactionType
{
    Payin,
    PayinReturn,
    Refund,
    Payout,
    PayoutReturn,
    Fee,
    Chargback,
    Representment,
    Transfer,
    TransferWallet,
    RollingReserve
}