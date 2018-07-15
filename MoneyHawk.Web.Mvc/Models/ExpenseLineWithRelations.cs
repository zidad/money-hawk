using MoneyHawk.Core;

namespace MoneyHawk.Web.Models
{
    public class ExpenseLineWithRelations
    {
        public Purchase Expense { get; set; }
        public Line Line { get; set; }
        //public Contact Contact { get; set; }
        public LedgerAccount Ledger { get; set; }

        public TaxRate Tax { get; set; }
    }
}