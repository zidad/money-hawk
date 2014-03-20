using System.Collections.Generic;
using System.Linq;
using System;
using MoneyHawk.Core.Invoices;
using ServiceStack;

namespace MoneyHawk.Core
{
    /// <summary>
    ///  Description	Method & URL
    /// Get all invoices	GET	/api/v1.0/invoices.xml
    /// Get all invoices filtered	GET	/api/v1.0/invoices/filter/:filter.xml
    /// Get all invoices filtered advanced by parameters	POST	/api/v1.0/invoices/filter/advanced.xml
    /// Get invoice	GET	/api/v1.0/invoices/:id.xml
    /// Get invoice by invoice_id	GET	/api/v1.0/invoices/invoice_id/:invoice_id.xml
    /// Create new invoice	POST	/api/v1.0/invoices.xml
    /// Update invoice	PUT	/api/v1.0/invoices/:id.xml
    /// Send invoice	PUT	/api/v1.0/invoices/:id/send_invoice.xml
    /// Send invoice reminder	PUT	/api/v1.0/invoices/:id/send_reminder.xml
    /// Register payment	POST	/api/v1.0/invoices/:id/payments.xml
    /// Delete invoice	DELETE	/api/v1.0/invoices/:id.xml
    /// Get list of invoices for syncing	GET	/api/v1.0/invoices/sync_list_ids.xml
    /// Get specified invoices for syncing	POST	/api/v1.0/invoices/sync_fetch_ids.xml
    /// </summary>
    public class InvoiceDataSource : DataSource<Invoice>
    {
        public InvoiceDataSource(IServiceClient api)
            : base(api)
        {
        }

        // Get all invoices	GET	/api/v1.0/invoices.xml
        public override IEnumerable<Invoice> GetAll()
        {
            return api.Get<List<Invoice>>("invoices.json");
        }

        // Get all invoices filtered	GET	/api/v1.0/invoices/filter/:filter.xml
        public IEnumerable<Invoice> GetAll(InvoiceSelection filter)
        {
            return api.Get<InvoiceList>("invoices/filter/"+filter.ToString().ToLower()+".json").Invoices;
        }

        //Get all invoices filtered advanced by parameters	POST	/api/v1.0/invoices/filter/advanced.xml
        //Get invoice	GET	/api/v1.0/invoices/:id.xml
        //Get invoice by invoice_id	GET	/api/v1.0/invoices/invoice_id/:invoice_id.xml
        //Create new invoice	POST	/api/v1.0/invoices.xml
        //Update invoice	PUT	/api/v1.0/invoices/:id.xml
        //Send invoice	PUT	/api/v1.0/invoices/:id/send_invoice.xml
        //Send invoice reminder	PUT	/api/v1.0/invoices/:id/send_reminder.xml
        //Register payment	POST	/api/v1.0/invoices/:id/payments.xml
        //Delete invoice	DELETE	/api/v1.0/invoices/:id.xml
        //Get list of invoices for syncing	GET	/api/v1.0/invoices/sync_list_ids.xml
        //Get specified invoices for syncing	POST	/api/v1.0/invoices/sync_fetch_ids.xml

    }
}