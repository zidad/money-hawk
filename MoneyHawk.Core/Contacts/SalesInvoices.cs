using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyHawk.Core
{
    /// <summary>
    /// https://developer.moneybird.com/api/sales_invoices/
    /// /sales_invoices	GET	List all invoices
    /// /sales_invoices/synchronization	GET	List all ids and versions
    /// /sales_invoices/synchronization	POST	Fetch sales invoices with given ids
    /// /sales_invoices/:id	GET	Get an invoice by id
    /// /sales_invoices/find_by_invoice_id/:invoice_id	GET	Get an invoice by invoice_id
    /// /sales_invoices	POST	Creates a new invoice
    /// /sales_invoices/:id	PATCH	Updates an invoice
    /// /sales_invoices/:id	DELETE	Destroys an invoice
    /// /sales_invoices/:sales_invoice_id/notes	POST	Adds note to entity
    /// /sales_invoices/:sales_invoice_id/notes/:id	DELETE	Destroys note from entity
    /// /sales_invoices/:id/send_invoice	PATCH	Sends an invoice
    /// /sales_invoices/:id/register_payment	PATCH	Register a payment
    /// /sales_invoices/:id/register_payment_creditinvoice	PATCH	Register a payment for a creditinvoice
    /// /sales_invoices/send_reminders	POST	Sends a reminder
    /// /sales_invoices/:id/duplicate_creditinvoice	PATCH	Duplicate to credit invoice
    /// /sales_invoices/:id/mark_as_uncollectible	PATCH	Mark as uncollectible
    /// /sales_invoices/:id/attachments	POST	Add attachment to sales invoice
    /// </summary>
    public class SalesInvoices : DataSource<SalesInvoice>
    {
        const string format = "json";
        const string sales_invoices = "sales_invoices";

        public SalesInvoices(MoneyBirdClient client)
            : base(client)
        {
        }

        /// /sales_invoices	GET	List all invoices
        public override async Task<IEnumerable<SalesInvoice>> GetAll()
        {
            var invoiceWrappers = await client.GetAsync<SalesInvoice[]>($"{sales_invoices}.{format}");
            var invoices = invoiceWrappers;
            return invoices.Body.ToArray();
        }

        /// /sales_invoices/synchronization	GET	List all ids and versions
        /// /sales_invoices/synchronization	POST	Fetch sales invoices with given ids
        /// /sales_invoices/:id	GET	Get an invoice by id
        /// /sales_invoices/find_by_invoice_id/:invoice_id	GET	Get an invoice by invoice_id
        /// /sales_invoices	POST	Creates a new invoice
        /// /sales_invoices/:id	PATCH	Updates an invoice
        /// /sales_invoices/:id	DELETE	Destroys an invoice
        /// /sales_invoices/:sales_invoice_id/notes	POST	Adds note to entity
        /// /sales_invoices/:sales_invoice_id/notes/:id	DELETE	Destroys note from entity
        /// /sales_invoices/:id/send_invoice	PATCH	Sends an invoice
        /// /sales_invoices/:id/register_payment	PATCH	Register a payment
        /// /sales_invoices/:id/register_payment_creditinvoice	PATCH	Register a payment for a creditinvoice
        /// /sales_invoices/send_reminders	POST	Sends a reminder
        /// /sales_invoices/:id/duplicate_creditinvoice	PATCH	Duplicate to credit invoice
        /// /sales_invoices/:id/mark_as_uncollectible	PATCH	Mark as uncollectible
        /// /sales_invoices/:id/attachments	POST	Add attachment to sales invoice       
        public async Task<SalesInvoice> GetById(int id)
        {
            var result = await client.GetAsync<SalesInvoice>($"{sales_invoices}/{id}." + format);

            return result.Body;
        }

        //https://moneybird.com/api/v2/178215432957724585/sales_invoices.json?filter=period:201501..201512
        public async Task<IEnumerable<SalesInvoice>> Filter(DateTime start, DateTime end)
        {
            var result = (await client.GetAsync<SalesInvoice[]>(
                $"{sales_invoices}.{format}?filter=period:{start:yyyyMM}..{end:yyyyMM}"));

            return result.Body.ToArray();
        }

    }
}