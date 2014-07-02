using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MoneyHawk.Core;

namespace MoneyHawk.Web.Controllers
{
    [Authorize]
    public class LedgerAccountController : Controller
    {
        private readonly IMoneyBirdApi moneybird;

        public LedgerAccountController()
        {
            moneybird = MoneyBirdFactory.GetInstance();
            //moneybird = MoneyBirdFactory.GetInstanceOAuth();
        }

        public ActionResult Index()
        {
            IList<LedgerAccount> ledgerAccounts = moneybird.LedgerAccounts.GetAll().ToList();

            return View(ledgerAccounts);
        }
    }
}