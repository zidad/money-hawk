using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MoneyHawk.Core;
using MoneyHawk.Web.Controllers;

namespace MoneyHawk.Web.Mvc.Controllers
{
    [Authorize]
    public class ExpenseController : Controller
    {
        private readonly IMoneyBirdApi moneybird;

        public ExpenseController()
        {
            //moneybird = MoneyBirdFactory.GetInstanceOAuth();
            moneybird = MoneyBirdFactory.GetInstance();
        }

        public ActionResult Index()
        {
            IEnumerable<IncomingInvoice> allInvoices = moneybird.IncomingInvoices.GetAll();

            return View(allInvoices);
        }
    }
}