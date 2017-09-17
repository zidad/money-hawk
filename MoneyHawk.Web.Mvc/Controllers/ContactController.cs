using System.Threading.Tasks;
using System.Web.Mvc;
using MoneyHawk.Core;

namespace MoneyHawk.Web.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        readonly IMoneyBirdClient moneybird;

        public ContactController(MoneyBirdClient moneybird)
        {
            this.moneybird = moneybird;
        }

        public async Task<ActionResult> Index()
        {
            var contacts = await moneybird.Contacts.GetAll();

            return View(contacts);
        }
    }
}