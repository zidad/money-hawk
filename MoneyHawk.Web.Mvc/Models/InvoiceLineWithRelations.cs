using MoneyHawk.Core;
using MoneyHawk.Core.Invoices;

namespace MoneyHawk.Web.Controllers
{
    public class InvoiceLineWithRelations
    {
        public Invoice Invoice { get; set; }
        public Details Details { get; set; }
        public Contact Contact { get; set; }
    }
}