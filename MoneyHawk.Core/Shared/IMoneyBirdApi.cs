namespace MoneyHawk.Core
{
    public interface IMoneyBirdApi
    {
        InvoiceDataSource Invoices { get; }

        LedgerAccountDataSource LedgerAccounts { get; }

        IncomingInvoicesDataSource IncomingInvoices { get; }

        ContactDataSource Contacts { get; }

        T Get<T>(string url) where T : class;

        T Put<T>(string url, T data) where T : class;

        T Post<T>(string url, T data) where T : class;

        T Delete<T>(string url, T data) where T : class;
    }
}