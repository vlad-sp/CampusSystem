namespace CampusSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class CampusSystemDbContext : IdentityDbContext<User>
    {
        public CampusSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Room> Rooms { get; set; }

        public IDbSet<Floor> Floors { get; set; }

        public IDbSet<ApartmentBuilding> AppartmentBuildings { get; set; }

        public IDbSet<News> News { get; set; }

        public IDbSet<Consumption> Consumptions { get; set; }

        public IDbSet<ConsumptionPrice> ConsumptionPrices { get; set; }

        public static CampusSystemDbContext Create()
        {
            return new CampusSystemDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
