namespace CampusSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class CampusSystemDbContext : IdentityDbContext<User>
    {
        public CampusSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static CampusSystemDbContext Create()
        {
            return new CampusSystemDbContext();
        }
    }
}
