using System.Linq;
using System;
using System.Web;
using MoneyHawk.Core;

namespace MoneyHawk.Web.Controllers
{
    public static class MoneyBirdFactory
    {
        public static IMoneyBirdApi GetInstance()
        {
            var username = (string)HttpContext.Current.Session["username"];
            var password = (string)HttpContext.Current.Session["password"];
            var subdomain = (string)HttpContext.Current.Session["subdomain"];

            if (username.HasNoData() || password.HasNoData() || subdomain.HasNoData())
                throw new Exception("Missing data from session, please log in");

            return new CachedMoneyBirdApi(new MoneyBirdApi(subdomain, username, password));
        }
        
        public static IMoneyBirdApi GetInstanceOAuth()
        {
            const string subdomain = "net-industry";
            const string oAuthToken = "YnYWmd1qbKGeoq7eAQU2pBNchJmRTfEMnpxRYh5x";
            
            return new MoneyBirdApi(subdomain, oAuthToken);
        }
    }
}