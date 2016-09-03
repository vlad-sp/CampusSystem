namespace CampusSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConsumptionPricesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConsumptionPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ElectricityPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ColdWaterPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HotWaterPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HeatingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            DropColumn("dbo.Consumptions", "ElectricityPrice");
            DropColumn("dbo.Consumptions", "ColdWaterPrice");
            DropColumn("dbo.Consumptions", "HotWaterPrice");
            DropColumn("dbo.Consumptions", "HeatingPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Consumptions", "HeatingPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Consumptions", "HotWaterPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Consumptions", "ColdWaterPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Consumptions", "ElectricityPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropIndex("dbo.ConsumptionPrices", new[] { "IsDeleted" });
            DropTable("dbo.ConsumptionPrices");
        }
    }
}
