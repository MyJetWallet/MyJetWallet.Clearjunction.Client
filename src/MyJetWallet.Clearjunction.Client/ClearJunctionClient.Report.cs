using System;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.ClearJunction.Models;
using MyJetWallet.ClearJunction.Models.Reports;
using MyJetWallet.ClearJunction.Models.Statements;

namespace MyJetWallet.ClearJunction
{
    public partial class ClearJunctionClient
    {
        #region Reports

        public async Task<WebCallResult<Report>> GetReportsAsync(string walletUuid, DateTime from, DateTime to,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<Report>($"v7/gate/reports/transactionReport", new GetReportRequest()
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
