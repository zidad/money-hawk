using System.Collections.Generic;
using System.Web.Mvc;
using MoneyHawk.Core;
using MoneyHawk.Core.Invoices;

namespace MoneyHawk.Web.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        public InvoiceController()
        {
            moneybird = MoneyBirdFactory.GetInstance();
        }

        private readonly IMoneyBirdApi moneybird;

        public ActionResult Index()
        {
            IEnumerable<Invoice> allInvoices = moneybird.Invoices.GetAll();

            return View(allInvoices);
        }
    }
}