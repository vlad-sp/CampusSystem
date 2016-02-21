namespace CampusSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMissingPropertyToModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "RoomName", c => c.String());
            AddColumn("dbo.Rooms", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Rooms", "UserId");
            AddForeignKey("dbo.Rooms", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Rooms", new[] { "UserId" });
            DropColumn("dbo.Rooms", "UserId");
            DropColumn("dbo.Rooms", "RoomName");
        }
    }
}
