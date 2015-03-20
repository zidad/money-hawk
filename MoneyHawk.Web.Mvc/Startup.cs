using Microsoft.Owin;
using MoneyHawk.Web;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace MoneyHawk.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
