using System;
using System.Linq;
using System.Web.Mvc;
using MoneyHawk.Core;

namespace MoneyHawk.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMoneyBirdApi moneybird;

        public HomeController()
        {
            moneybird = MoneyBirdFactory.GetInstanceOAuth();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}