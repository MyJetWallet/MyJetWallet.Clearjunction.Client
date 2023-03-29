using System;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.ClearJunction.Models;
using MyJetWallet.ClearJunction.Models.RequisitesAllocation;
using MyJetWallet.ClearJunction.Models.Statements;

namespace MyJetWallet.ClearJunction
{
    public partial class ClearJunctionClient
    {
        #region Wallet
        public async Task<WebCallResult<IbanInformation>> GetWalletAsync(string wallet, bool returnPaymentMethods,
            CancellationToken cancellationToken = default)
        {
            if (returnPaymentMethods)
            {
                return await GetAsync<IbanInformation>(
                    $"v7/bank/wallets/{wallet}?returnPaymentMethods=true",
                    cancellationToken);
            }

            return await GetAsync<IbanInformation>(
                $"v7/bank/wallets/{wallet}",
                cancellationToken);
        }
        #endregion
    }
}
