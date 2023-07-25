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
        #region RequestAlocations

        public async Task<WebCallResult<RequestAllocationResponse>> CreateIbanAsync(RequestAllocation requestAllocation,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<RequestAllocationResponse>(
                $"v7/gate/allocate/v3/create/iban",
                requestAllocation,
                cancellationToken);
        }

        public async Task<WebCallResult<IbanAllocation>> GetIbanByOrderReferenceAsync(string orderReference,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<IbanAllocation>(
                $"v7/gate/allocate/v2/status/iban/orderReference/{orderReference}",
                cancellationToken);
        }

        public async Task<WebCallResult<IbanAllocation>> GetIbanByClientOrderAsync(string clientOrder,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<IbanAllocation>(
                $"v7/gate/allocate/v2/status/iban/clientOrder/{clientOrder}",
                cancellationToken);
        }

        public async Task<WebCallResult<IbanInformation>> GetIbanInfoAsync(string iban,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<IbanInformation>(
                $"v7/gate/allocate/v2/info/iban/{iban}",
                cancellationToken);
        }

        public async Task<WebCallResult<CustomerIbanList>> GetIbanListByClientCustomerIdAsync(string clientCustomerId,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<CustomerIbanList>(
                $"v7/gate/allocate/v2/list/iban/{clientCustomerId}",
                cancellationToken);
        }
        

        #endregion
    }
}
