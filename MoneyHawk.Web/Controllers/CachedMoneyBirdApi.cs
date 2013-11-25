using System.Linq;
using System;

namespace MoneyHawk.Web.Controllers
{
    using MoneyHawk.Core;

    public class CachedMoneyBirdApi : IMoneyBirdApi
    {
        private readonly IMoneyBirdApi moneyBirdApi;
        private readonly Cache cache;

        public CachedMoneyBirdApi(IMoneyBirdApi moneyBirdApi)
        {
            this.moneyBirdApi = moneyBirdApi;
            this.cache = new Cache();
        }

        public InvoiceDataSource Invoices
        {
            get
            {
                return new InvoiceDataSource(this);
            }
        }

        public LedgerAccountDataSource LedgerAccounts
        {
            get
            {
                return new LedgerAccountDataSource(this);
            }
        }

        public IncomingInvoicesDataSource IncomingInvoices
        {
            get
            {
                return new IncomingInvoicesDataSource(this);
            }
        }

        public ContactDataSource Contacts
        {
            get
            {
                return new ContactDataSource(this);
            }
        }

        public T Get<T>(string url) where T : class, new()
        {
            return this.cache.GetOrAdd(url, () => this.moneyBirdApi.Get<T>(url));
        }

        public T Put<T>(string url, T data) where T : class
        {
            return this.moneyBirdApi.Put(url, data);
        }

        public T Post<T>(string url, T data) where T : class
        {
            return this.moneyBirdApi.Post(url, data);
        }

        public T Delete<T>(string url, T data) where T : class
        {
            return this.moneyBirdApi.Delete(url, data);
        }
    }
}