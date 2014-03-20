using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MoneyHawk.Core;
using MoneyHawk.Core.Invoices;
using MoneyHawk.Web.Mvc.Models;

namespace MoneyHawk.Web.Mvc.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        public InvoiceController()
        {
            moneybird = MoneyBirdFactory.GetInstance();
        }

        private UserManager<ApplicationUser> userManager;

        private readonly IMoneyBirdApi moneybird;

        public ActionResult Index()
        {
            IEnumerable<Invoice> allInvoices = moneybird.Invoices.GetAll();

            return View(allInvoices);
        }
    }
}