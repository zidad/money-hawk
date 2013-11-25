using System.Collections.Generic;
using System.Linq;
using System;
using System.Web.Mvc;
using MoneyHawk.Core;

namespace MoneyHawk.Web.Controllers
{
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