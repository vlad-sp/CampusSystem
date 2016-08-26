namespace CampusSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RoomFreeBedsCountFixed2 : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.ApartmentBuildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        CampusHostName = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.Floors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FloorNumber = c.Int(nullable: false),
                        BuildingId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApartmentBuildings", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomName = c.String(),
                        BedsCount = c.Int(nullable: false),
                        Area = c.Double(nullable: false),
                        HasBalcon = c.Boolean(nullable: false),
                        FloorId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Floors", t => t.FloorId, cascadeDelete: true)
                .Index(t => t.FloorId)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        University = c.String(),
                        FacultyName = c.String(),
                        FacultyNumber = c.String(),
                        Course = c.Int(nullable: false),
                        GroupNumber = c.Int(nullable: false),
                        RoomId = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .Index(t => t.RoomId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            this.CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            this.CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            this.CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            this.CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
        }

        public override void Down()
        {
           this.DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
           this.DropForeignKey("dbo.AspNetUsers", "RoomId", "dbo.Rooms");
           this.DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
           this.DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
           this.DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
           this.DropForeignKey("dbo.Rooms", "FloorId", "dbo.Floors");
           this.DropForeignKey("dbo.Floors", "BuildingId", "dbo.ApartmentBuildings");
           this.DropIndex("dbo.AspNetRoles", "RoleNameIndex");
           this.DropIndex("dbo.News", new[] { "IsDeleted" });
           this.DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
           this.DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
           this.DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
           this.DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
           this.DropIndex("dbo.AspNetUsers", "UserNameIndex");
           this.DropIndex("dbo.AspNetUsers", new[] { "RoomId" });
           this.DropIndex("dbo.Rooms", new[] { "IsDeleted" });
           this.DropIndex("dbo.Rooms", new[] { "FloorId" });
           this.DropIndex("dbo.Floors", new[] { "IsDeleted" });
           this.DropIndex("dbo.Floors", new[] { "BuildingId" });
           this.DropIndex("dbo.ApartmentBuildings", new[] { "IsDeleted" });
           this.DropTable("dbo.AspNetRoles");
           this.DropTable("dbo.News");
           this.DropTable("dbo.AspNetUserRoles");
           this.DropTable("dbo.AspNetUserLogins");
           this.DropTable("dbo.AspNetUserClaims");
           this.DropTable("dbo.AspNetUsers");
           this.DropTable("dbo.Rooms");
           this.DropTable("dbo.Floors");
           this.DropTable("dbo.ApartmentBuildings");
        }
    }
}
