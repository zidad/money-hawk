using System.Collections.Generic;
using System.Linq;
using System;
using System.Web.Mvc;
using MoneyHawk.Core;
using MoneyHawk.Core.Invoices;

namespace MoneyHawk.Web.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IMoneyBirdApi moneybird;

        public InvoiceController()
        {
            moneybird = MoneyBirdFactory.GetInstance();
            //moneybird = MoneyBirdFactory.GetInstanceOAuth();
        }

        public ActionResult Index()
        {
            IEnumerable<Invoice> allInvoices = moneybird.Invoices.GetAll();

            return View(allInvoices);
        }
    }
}