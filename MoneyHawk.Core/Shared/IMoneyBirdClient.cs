namespace MoneyHawk.Core
{
    public interface IMoneyBirdClient
    {
        SalesInvoices SalesInvoices { get; }

        LedgerAccounts LedgerAccounts { get; }

        Receipts Receipts { get; }

        Contacts Contacts { get; }

        TaxRates TaxRates { get; }

        PurchaseInvoices PurchaseInvoices { get; }
    }
}