using System;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.ClearJunction.Models;
using MyJetWallet.ClearJunction.Models.Statements;

namespace MyJetWallet.ClearJunction
{
    public partial class ClearJunctionClient
    {
        #region Statements

        public async Task<WebCallResult<Statement>> GetStatementAsync(string walletUuid, DateTime from, DateTime to,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<Statement>($"v7/gate/wallets/statement", new GetStatementRequest()
            {
                DateFrom = from.ToString("yyyy-MM-dd"),
                DateTo = to.ToString("yyyy-MM-dd"),
                WalletUuid = walletUuid
            },
                cancellationToken);
        }

        #endregion
    }
}
