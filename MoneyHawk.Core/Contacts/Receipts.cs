using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net.Text;

namespace MoneyHawk.Core
{
    /// <summary>
    /// https://developer.moneybird.com/api/documents_receipts/
    /// /documents/receipts/synchronization	GET	List ids and versions of receipts
    /// /documents/receipts/synchronization	POST	Fetch receipts with given ids
    /// /documents/receipts	GET	Get receipts
    /// /documents/receipts/:id	GET	Get receipts
    /// /documents/receipts	POST	Create a new receipts
    /// /documents/receipts/:id	DELETE	Delete a receipts
    /// /documents/receipts/:id	PATCH	Update a receipts
    /// /documents/receipts/:id/register_payment	PATCH	Register a payment for a receipt
    /// /documents/receipts/:id/attachments	POST	Add attachment to receipt
    /// </summary>
    public class Receipts
    {
        readonly MoneyBirdClient client;
        const string format = "json";

        public Receipts(MoneyBirdClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        //documents/receipts	GET	Get receipts
        public async Task<IEnumerable<Receipt>> GetAll()
        {
            var incomingInvoices = await client.GetAsync<Receipt[]>("documents/receipts." + format);
            return incomingInvoices.Body.ToArray();
        }

        //https://moneybird.com/api/v2/178215432957724585/documents/receipts.json?filter=period:201501..201512
        public async Task<IEnumerable<Receipt>> Filter(DateTime start, DateTime end)
        {
            var url = $"documents/receipts.{format}?filter=period:{start:yyyyMM}..{end:yyyyMM}";
            var invoices = new List<Receipt>();
            Result<Receipt[]> result;
            do
            {
                result = await client.GetAsync<Receipt[]>(url);
                invoices.AddRange(result.Body);
            }
            while ((url = result.Next).HasValue());
            return invoices;
        }
    }
}