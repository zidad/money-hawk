using System.Threading.Tasks;

namespace MoneyHawk.Core
{
    using System.Collections.Generic;
    using System.Linq;
    
    public class LedgerAccounts : DataSource<LedgerAccount>
    {
        public LedgerAccounts(MoneyBirdClient client)
            : base(client)
        {
        }

        public override async Task<IEnumerable<LedgerAccount>> GetAll()
        {
            return (await client.GetAsync<LedgerAccount[]>("ledger_accounts.json")).Body.ToArray();
        }
    }
}