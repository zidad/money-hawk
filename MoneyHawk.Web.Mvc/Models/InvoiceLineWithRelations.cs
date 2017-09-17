using MoneyHawk.Core;

namespace MoneyHawk.Web.Controllers
{
    public class InvoiceLineWithRelations
    {
        public SalesInvoice Invoice { get; set; }
        public Line Line { get; set; }
        public TaxRate Tax { get; set; }

        //public Contact Contact { get; set; }
    }
}