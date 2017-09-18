using System.Data.Entity.SqlServer;

namespace MoneyHawk.Web.Mvc.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    public class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient",() => new SqlAzureExecutionStrategy(1, TimeSpan.FromSeconds(30))); 
        }

    }

    internal sealed class Configuration : DbMigrationsConfiguration<MoneyHawk.Web.Mvc.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MoneyHawk.Web.Mvc.Models.ApplicationDbContext";
            
           
        }

        protected override void Seed(MoneyHawk.Web.Mvc.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
