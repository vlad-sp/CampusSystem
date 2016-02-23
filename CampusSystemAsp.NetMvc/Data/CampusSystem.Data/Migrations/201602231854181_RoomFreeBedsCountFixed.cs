namespace CampusSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RoomFreeBedsCountFixed : DbMigration
    {
        public override void Up()
        {
            this.DropColumn("dbo.Rooms", "FreeBeds");
        }

        public override void Down()
        {
            this.AddColumn("dbo.Rooms", "FreeBeds", c => c.Int(nullable: false));
        }
    }
}
