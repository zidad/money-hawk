using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyHawk.Core
{
    /// <summary>
    /// GET /tax_rates(.:format)
    /// </summary>
    public class TaxRates : DataSource<TaxRate>
    {
        public TaxRates(MoneyBirdClient client)
            : base(client)
        {
        }

        /// GET /tax_rates(.:format)
        public override async Task<IEnumerable<TaxRate>> GetAll()
        {
            var taxRates = (await client.GetAsync<TaxRate[]>("tax_rates.json")).Body;

            return taxRates.ToArray();
        }
    }
}