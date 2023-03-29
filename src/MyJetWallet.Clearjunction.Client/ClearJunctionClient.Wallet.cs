using System;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.ClearJunction.Models;
using MyJetWallet.ClearJunction.Models.RequisitesAllocation;
using MyJetWallet.ClearJunction.Models.Statements;
using MyJetWallet.ClearJunction.Models.Wallet;

namespace MyJetWallet.ClearJunction
{
    public partial class ClearJunctionClient
    {
        #region Wallet
        public async Task<WebCallResult<Wallet>> GetWalletAsync(string wallet, bool returnPaymentMethods = false,
            CancellationToken cancellationToken = default)
        {
            if (returnPaymentMethods)
            {
                return await GetAsync<Wallet>(
                    $"v7/bank/wallets/{wallet}?returnPaymentMethods=true",
                    cancellationToken);
            }

            return await GetAsync<Wallet>(
                $"v7/bank/wallets/{wallet}",
                cancellationToken);
        }
        #endregion
    }
}
