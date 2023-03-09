namespace MyJetWallet.ClearJunction.Models.Payins;

public enum PayinNotificationStatus
{
    Created = 0,
    Expired = 1,
    Canceled = 2,
    Rejected = 3,
    Returned = 4,
    Pending = 5,
    Authorized = 6,
    Captured = 7,
    Settled = 8,
    Declined = 9,
}