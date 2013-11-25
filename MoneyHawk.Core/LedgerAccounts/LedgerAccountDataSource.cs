using System.Linq;
using System;

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
        public LedgerAccountDataSource(IMoneyBirdApi api)
            : base(api)
        {
        }

        // Get all invoices GET /api/v1.0/ledger_accounts.xml
        public override IEnumerable<LedgerAccount> GetAll()
        {
            var ledgerAccountList = this.api.Get<List<LedgerAccount>>("ledger_accounts.xml");

            return ledgerAccountList;
        }
    }
}