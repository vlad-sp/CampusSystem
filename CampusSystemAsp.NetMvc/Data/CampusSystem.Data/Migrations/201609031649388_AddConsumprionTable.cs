namespace CampusSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConsumprionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consumptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Electricity = c.Double(nullable: false),
                        ElectricityPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ColdWater = c.Double(nullable: false),
                        ColdWaterPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HotWater = c.Double(nullable: false),
                        HotWaterPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Heating = c.Double(nullable: false),
                        HeatingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RoomId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consumptions", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Consumptions", new[] { "IsDeleted" });
            DropIndex("dbo.Consumptions", new[] { "RoomId" });
            DropTable("dbo.Consumptions");
        }
    }
}
