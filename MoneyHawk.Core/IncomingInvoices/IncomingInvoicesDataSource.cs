using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack;

namespace MoneyHawk.Core
{
    public class IncomingInvoicesDataSource
    {
        private readonly IServiceClient api;
        private const string extension = "json";

        public IncomingInvoicesDataSource(IServiceClient api)
        {
            if (api == null) throw new ArgumentNullException("api");
            this.api = api;
        }

        ///Get all incoming invoices	GET	/api/v1.0/incoming_invoices.xml
        public IEnumerable<IncomingInvoice> GetAll()
        {
            var incomingInvoiceWrappers = api.Get<IncomingInvoiceWrapper[]>("incoming_invoices." + extension);
            var incomingInvoices = incomingInvoiceWrappers.Select(w=>w.IncomingInvoice);
            return incomingInvoices.ToArray();
        }

        ///Get an incoming invoice	GET	/api/v1.0/incoming_invoices/:id.xml
        public IncomingInvoice GetById(int id) 
        {
            return api.Get<IncomingInvoice>(string.Format("incoming_invoices/{0}." + extension, id));
        }

        ///Create a new incoming invoice	POST	/api/v1.0/incoming_invoices.xml
        public void Create(IncomingInvoice incomingInvoice) { throw new NotImplementedException(); }

        ///Update an incoming invoice	PUT	/api/v1.0/incoming_invoices/:id.xml
        public void Update(IncomingInvoice incomingInvoice) { throw new NotImplementedException(); }

        ///Register payment	POST	/api/v1.0/incoming_invoices/:id/payments.xml
        public void Register(InvoicePayment expense) { throw new NotImplementedException(); }

        ///Delete an incoming invoice	DELETE	/api/v1.0/incoming_invoices/:id.xml
        public void Delete(IncomingInvoice incomingInvoice) { throw new NotImplementedException(); }

        ///Get list of incoming invoices for syncing	GET	/api/v1.0/incoming_invoices/sync_list_ids.xml
        public IEnumerable<int> GetAllForSyncing() { throw new NotImplementedException(); }

        ///Get specified incoming invoices for syncing	POST	/api/v1.0/incoming_invoices/sync_fetch_ids.xml
        public IEnumerable<int> GetAllForSyncing(IEnumerable<int> ids) { throw new NotImplementedException(); }
    
    }
}