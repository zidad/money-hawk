namespace MoneyHawk.Core
{
    public interface IMoneyBirdApi
    {
        InvoiceDataSource Invoices { get; }

        LedgerAccountDataSource LedgerAccounts { get; }

        IncomingInvoicesDataSource IncomingInvoices { get; }

        ContactDataSource Contacts { get; }
    }
}