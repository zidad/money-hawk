using System.Configuration;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin;
using MoneyHawk.Core;
using MoneyHawk.Web;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace MoneyHawk.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var authorizationToken = ConfigurationManager.AppSettings["MoneyBirdAuthorizationToken"];
            var administrationId = ConfigurationManager.AppSettings["MoneyBirdAdministrationId"];

            var client = new MoneyBirdClient(authorizationToken, administrationId);

            var builder = new ContainerBuilder();

            // STANDARD MVC SETUP:
            builder
                .RegisterInstance(client)
                .SingleInstance()
                .AsImplementedInterfaces()
                .AsSelf();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Run other optional steps, like registering model binders,
            // web abstractions, etc., then set the dependency resolver
            // to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // OWIN MVC SETUP:

            // Register the Autofac middleware FIRST, then the Autofac MVC middleware.
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();

            ConfigureAuth(app);
        }
    }
}
