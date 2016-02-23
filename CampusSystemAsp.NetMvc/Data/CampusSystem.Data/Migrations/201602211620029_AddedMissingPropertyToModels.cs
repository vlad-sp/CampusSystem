namespace CampusSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedMissingPropertyToModels : DbMigration
    {
        public override void Up()
        {
           this.AddColumn("dbo.Rooms", "RoomName", c => c.String());
           this.AddColumn("dbo.Rooms", "UserId", c => c.String(maxLength: 128));
           this.CreateIndex("dbo.Rooms", "UserId");
           this.AddForeignKey("dbo.Rooms", "UserId", "dbo.AspNetUsers", "Id");
        }

        public override void Down()
        {
           this.DropForeignKey("dbo.Rooms", "UserId", "dbo.AspNetUsers");
           this.DropIndex("dbo.Rooms", new[] { "UserId" });
           this.DropColumn("dbo.Rooms", "UserId");
           this.DropColumn("dbo.Rooms", "RoomName");
        }
    }
}
