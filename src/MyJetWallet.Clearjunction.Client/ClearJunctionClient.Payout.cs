using System;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.ClearJunction.Models;
using MyJetWallet.ClearJunction.Models.Payouts;
using MyJetWallet.ClearJunction.Models.RequisitesAllocation;
using MyJetWallet.ClearJunction.Models.Statements;
using MyJetWallet.ClearJunction.Models.Wallet;

namespace MyJetWallet.ClearJunction
{
    public partial class ClearJunctionClient
    {
        #region Payout

        public async Task<WebCallResult<SepaInstantPayoutResponse>> ExecuteSctPayoutAsync(
            SepaInstantPayout request,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<SepaInstantPayoutResponse>(
                $"v7/gate/payout/bankTransfer/eu",
                request, cancellationToken);
        }
        
        public async Task<WebCallResult<SepaInstantPayoutResponse>> ExecuteSepaInstantPayoutAsync(
            SepaInstantPayout request,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<SepaInstantPayoutResponse>(
                $"v7/gate/payout/bankTransfer/sepaInst",
                request, cancellationToken);
        }

        public async Task<WebCallResult<PayoutStatus>> GetPayoutStatusByOrderReferenceAsync(string orderReference,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PayoutStatus>(
                $"v7/gate/status/payout/orderReference/{orderReference}",
                cancellationToken);
        }

        public async Task<WebCallResult<PayoutStatus>> GetPayoutStatusByClientOrderAsync(string clientOrder,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PayoutStatus>(
                $"v7/gate/status/payout/clientOrder/{clientOrder}",
                cancellationToken);
        }
        #endregion
    }
}