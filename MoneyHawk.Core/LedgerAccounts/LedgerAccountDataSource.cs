using System.Linq;
using System;
using ServiceStack;

namespace MoneyHawk.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System;

    /// <summary>
    /// Description Method & URL
    /// Get all ledger accounts GET /api/v1.0/ledger_accounts.xml
    /// </summary>
    public class LedgerAccountDataSource : DataSource<LedgerAccount>
    {
        public LedgerAccountDataSource(IServiceClient api)
            : base(api)
        {
        }

        // Get all invoices GET /api/v1.0/ledger_accounts.xml
        public override IEnumerable<LedgerAccount> GetAll()
        {
            var ledgerAccountWrappers = api.Get<LedgerAccountWrapper[]>("ledger_accounts.json");
            var ledgerAccounts = ledgerAccountWrappers.Select(l=>l.LedgerAccount);
            var ledgerAccountList = ledgerAccounts.ToArray();
            return ledgerAccountList;
        }
    }
}