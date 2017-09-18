using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using MoneyHawk.Core;

namespace MoneyHawk.Web.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        readonly IMoneyBirdClient moneybird;

        public InvoiceController(MoneyBirdClient moneyBird)
        {
            this.moneybird = moneyBird;
        }

        public async Task<ActionResult> Index()
        {
            IEnumerable<SalesInvoice> allInvoices = await moneybird.SalesInvoices.GetAll();

            return View(allInvoices);
        }
    }
}