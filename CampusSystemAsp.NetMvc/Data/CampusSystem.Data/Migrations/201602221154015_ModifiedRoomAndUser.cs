namespace CampusSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ModifiedRoomAndUser : DbMigration
    {
        public override void Up()
        {
           this.DropForeignKey("dbo.Rooms", "UserId", "dbo.AspNetUsers");
           this.DropIndex("dbo.Rooms", new[] { "UserId" });
           this.AddColumn("dbo.AspNetUsers", "RoomId", c => c.Int(nullable: false));
           this.CreateIndex("dbo.AspNetUsers", "RoomId");
           this.AddForeignKey("dbo.AspNetUsers", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
           this.DropColumn("dbo.Rooms", "UserId");
        }

        public override void Down()
        {
           this.AddColumn("dbo.Rooms", "UserId", c => c.String(maxLength: 128));
           this.DropForeignKey("dbo.AspNetUsers", "RoomId", "dbo.Rooms");
           this.DropIndex("dbo.AspNetUsers", new[] { "RoomId" });
           this.DropColumn("dbo.AspNetUsers", "RoomId");
           this.CreateIndex("dbo.Rooms", "UserId");
           this.AddForeignKey("dbo.Rooms", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
