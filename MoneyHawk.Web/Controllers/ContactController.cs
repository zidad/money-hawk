using System.Collections.Generic;
using System.Linq;
using System;
using System.Web.Mvc;
using MoneyHawk.Core;

namespace MoneyHawk.Web.Controllers
{
    using MoneyHawk.Core.Invoices;

    public class ContactController : Controller
    {
        private readonly IMoneyBirdApi moneybird;

        public ContactController()
        {
            moneybird = MoneyBirdFactory.GetInstance();
            //moneybird = MoneyBirdFactory.GetInstanceOAuth();
        }

        public ActionResult Index()
        {
            var contacts = moneybird.Contacts.GetAll();

            return View(contacts);
        }
    }
}