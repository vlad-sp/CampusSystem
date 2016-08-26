namespace CampusSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ModifiedRoomAndUser2 : DbMigration
    {
        public override void Up()
        {
            this.DropForeignKey("dbo.AspNetUsers", "RoomId", "dbo.Rooms");
            this.DropIndex("dbo.AspNetUsers", new[] { "RoomId" });
            this.AlterColumn("dbo.AspNetUsers", "RoomId", c => c.Int());
            this.CreateIndex("dbo.AspNetUsers", "RoomId");
            this.AddForeignKey("dbo.AspNetUsers", "RoomId", "dbo.Rooms", "Id");
        }

        public override void Down()
        {
           this.DropForeignKey("dbo.AspNetUsers", "RoomId", "dbo.Rooms");
           this.DropIndex("dbo.AspNetUsers", new[] { "RoomId" });
           this.AlterColumn("dbo.AspNetUsers", "RoomId", c => c.Int(nullable: false));
           this.CreateIndex("dbo.AspNetUsers", "RoomId");
           this.AddForeignKey("dbo.AspNetUsers", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
        }
    }
}
