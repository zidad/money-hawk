using System.Threading.Tasks;
using System.Web.Mvc;
using MoneyHawk.Core;

namespace MoneyHawk.Web.Controllers
{
    [Authorize]
    public class ExpenseController : Controller
    {
        readonly IMoneyBirdClient moneybird;

        public ExpenseController(MoneyBirdClient moneybird)
        {
            this.moneybird = moneybird;
        }

        public async Task<ActionResult> Index()
        {
            var allInvoices = await moneybird.PurchaseInvoices.GetAll();

            return View(allInvoices);
        }
    }
}