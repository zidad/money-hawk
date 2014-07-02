using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MoneyHawk.Core;
using MoneyHawk.Web.Controllers;

namespace MoneyHawk.Web.Controllers
{
    [Authorize]
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