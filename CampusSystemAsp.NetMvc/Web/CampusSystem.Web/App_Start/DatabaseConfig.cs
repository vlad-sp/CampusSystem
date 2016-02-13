namespace CampusSystem.Web
{
    using System.Data.Entity;
    using CampusSystem.Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CampusSystemDbContext, Configuration>());
            CampusSystemDbContext.Create().Database.Initialize(true);
        }
    }
}