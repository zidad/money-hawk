using MoneyHawk.Core;
using ServiceStack;

namespace MoneyHawk.Web.Controllers
{
    public class CachedMoneyBirdApi : IMoneyBirdApi
    {
        private readonly IServiceClient cachedClient;

        public CachedMoneyBirdApi(IServiceClient cachedClient)
        {
            this.cachedClient = new CachedServiceClient(cachedClient);
        }

        public InvoiceDataSource Invoices
        {
            get
            {
                return new InvoiceDataSource(cachedClient);
            }
        }

        public LedgerAccountDataSource LedgerAccounts
        {
            get
            {
                return new LedgerAccountDataSource(cachedClient);
            }
        }

        public IncomingInvoicesDataSource IncomingInvoices
        {
            get
            {
                return new IncomingInvoicesDataSource(cachedClient);
            }
        }

        public ContactDataSource Contacts
        {
            get
            {
                return new ContactDataSource(cachedClient);
            }
        }
    }
}