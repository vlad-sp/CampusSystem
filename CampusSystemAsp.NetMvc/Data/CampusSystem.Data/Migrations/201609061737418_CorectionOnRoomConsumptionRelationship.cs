namespace CampusSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorectionOnRoomConsumptionRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consumptions", "Month", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Consumptions", "Month");
        }
    }
}
