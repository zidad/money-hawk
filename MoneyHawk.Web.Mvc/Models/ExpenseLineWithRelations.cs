using System.Linq;
using System.Runtime.Serialization;
using MoneyHawk.Core;

namespace MoneyHawk.Web.Controllers
{
    [DataContract]
    public class ExpenseLineWithRelations
    {
        public IncomingInvoice Expense { get; set; }
        public Details Details { get; set; }
        public Contact Contact { get; set; }
        public LedgerAccount Ledger { get; set; }

        public string Type1
        {
            get { return Ledger.Name.Split('-').Skip(1).FirstOrDefault() ?? ""; }
        }

        public string Type2
        {
            get { return Ledger.Name.Split('-').Skip(2).FirstOrDefault() ?? ""; }
        }
    }
}