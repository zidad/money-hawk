using System;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MoneyHawk.Core;
using MoneyHawk.Web.Mvc.Models;
using Net.Text;

namespace MoneyHawk.Web.Controllers
{
    public static class MoneyBirdFactory
    {
        public static IMoneyBirdClient GetInstance()
        {
            var manager =  HttpContext.Current.GetOwinContext().Authentication;
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = userManager.FindByName(manager.User.Identity.Name);

            var username = user.MoneyBirdUserName;
            var password = user.MoneyBirdPassword;
            var subdomain = user.MoneyBirdAccountName;

            if (username.HasNoValue() || password.HasNoValue() || subdomain.HasNoValue())
                throw new Exception("Missing data account, please log in");

            var defaultRestClient = MoneyBirdClient.CreateDefaultRestClient(subdomain, username, password);
            return new CachedMoneyBirdClient(defaultRestClient);
        }
    }
}