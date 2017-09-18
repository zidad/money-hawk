using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MoneyHawk.Core;

namespace MoneyHawk.Web.Controllers
{
    [Authorize]
    public class LedgerAccountController : Controller
    {
        readonly IMoneyBirdClient moneybird;

        public LedgerAccountController(MoneyBirdClient moneybird)
        {
            this.moneybird = moneybird;
        }

        public async Task<ActionResult> Index()
        {
            IList<LedgerAccount> ledgerAccounts = (await moneybird.LedgerAccounts.GetAll()).ToList();

            return View(ledgerAccounts);
        }
    }
}