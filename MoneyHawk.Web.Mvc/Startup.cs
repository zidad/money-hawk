using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoneyHawk.Web.Mvc.Startup))]
namespace MoneyHawk.Web.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
