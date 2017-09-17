using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net.Text;

namespace MoneyHawk.Core
{
    /// <summary>
    /// https://developer.moneybird.com/api/documents_purchase_invoices/
    /// /documents/purchase_invoices/synchronization	GET	List ids and versions of purchase invoices
    /// /documents/purchase_invoices/synchronization	POST	Fetch purchase invoices with given ids
    /// /documents/purchase_invoices	GET	Get purchase invoices
    /// /documents/purchase_invoices/:id	GET	Get purchase invoices
    /// /documents/purchase_invoices	POST	Create a new purchase invoices
    /// /documents/purchase_invoices/:id	DELETE	Delete a purchase invoices
    /// /documents/purchase_invoices/:id	PATCH	Update a purchase invoices
    /// /documents/purchase_invoices/:id/register_payment	PATCH	Register a payment for a purchase invoice
    /// /documents/purchase_invoices/:id/attachments	POST	Add attachment to purchase invoice
    /// </summary>
    public class PurchaseInvoices
    {
        readonly MoneyBirdClient client;
        const string format = "json";

        public PurchaseInvoices(MoneyBirdClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        //documents/receipts	GET	Get receipts
        public async Task<IEnumerable<PurchaseInvoice>> GetAll()
        {
            return (await client.GetAsync<PurchaseInvoice[]>($"documents/purchase_invoices.{format}")).Body.ToArray();
        }

        //https://moneybird.com/api/v2/178215432957724585/documents/purchase_invoices.json?filter=period:201501..201512
        public async Task<IEnumerable<PurchaseInvoice>> Filter(DateTime start, DateTime end)
        {
            var url = $"documents/purchase_invoices.{format}?filter=period:{start:yyyyMM}..{end:yyyyMM}";
            var invoices = new List<PurchaseInvoice>();
            Result<PurchaseInvoice[]> result;
            do
            {
                result = await client.GetAsync<PurchaseInvoice[]>(url);
                invoices.AddRange(result.Body);
            }
            while ((url = result.Next).HasValue());
            return invoices;
        }
    }
}