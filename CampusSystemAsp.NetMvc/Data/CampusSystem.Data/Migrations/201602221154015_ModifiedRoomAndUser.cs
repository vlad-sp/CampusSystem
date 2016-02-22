namespace CampusSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedRoomAndUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Rooms", new[] { "UserId" });
            AddColumn("dbo.AspNetUsers", "RoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "RoomId");
            AddForeignKey("dbo.AspNetUsers", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
            DropColumn("dbo.Rooms", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "UserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.AspNetUsers", "RoomId", "dbo.Rooms");
            DropIndex("dbo.AspNetUsers", new[] { "RoomId" });
            DropColumn("dbo.AspNetUsers", "RoomId");
            CreateIndex("dbo.Rooms", "UserId");
            AddForeignKey("dbo.Rooms", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
