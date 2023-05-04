using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.ClearJunction.Models;
using MyJetWallet.ClearJunction.Models.SepaIban;

namespace MyJetWallet.ClearJunction
{
    public partial class ClearJunctionClient
    {
        #region Requisite

        public async Task<WebCallResult<SepaIban>> CheckRequisiteAsync(string iban,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<SepaIban>(
                $"v7/gate/checkRequisite/bankTransfer/eu/iban/{iban}",
                cancellationToken);
        }

        #endregion
    }
}