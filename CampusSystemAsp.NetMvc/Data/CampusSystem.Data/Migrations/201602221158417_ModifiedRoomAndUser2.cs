namespace CampusSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedRoomAndUser2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "RoomId", "dbo.Rooms");
            DropIndex("dbo.AspNetUsers", new[] { "RoomId" });
            AlterColumn("dbo.AspNetUsers", "RoomId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "RoomId");
            AddForeignKey("dbo.AspNetUsers", "RoomId", "dbo.Rooms", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "RoomId", "dbo.Rooms");
            DropIndex("dbo.AspNetUsers", new[] { "RoomId" });
            AlterColumn("dbo.AspNetUsers", "RoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "RoomId");
            AddForeignKey("dbo.AspNetUsers", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
        }
    }
}
