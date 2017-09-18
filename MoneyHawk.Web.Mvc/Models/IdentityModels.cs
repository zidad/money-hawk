using Microsoft.AspNet.Identity.EntityFramework;

namespace MoneyHawk.Web.Mvc.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string MoneyBirdUserName { get; set; }

        public string MoneyBirdAccountName { get; set; }

        public string MoneyBirdPassword { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema:false)
        {

        }
    }
}