namespace CampusSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
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
            
            CreateTable(
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
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BedsCount = c.Int(nullable: false),
                        Area = c.Double(nullable: false),
                        HasBalcon = c.Boolean(nullable: false),
                        FreeBeds = c.Int(nullable: false),
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
            
            CreateTable(
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
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        University = c.String(),
                        FacultyName = c.String(),
                        FacultyNumber = c.String(),
                        Course = c.Int(nullable: false),
                        GroupNumber = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            AddColumn("dbo.AspNetUsers", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "StudentId");
            AddForeignKey("dbo.AspNetUsers", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Rooms", "FloorId", "dbo.Floors");
            DropForeignKey("dbo.Floors", "BuildingId", "dbo.ApartmentBuildings");
            DropIndex("dbo.Students", new[] { "IsDeleted" });
            DropIndex("dbo.AspNetUsers", new[] { "StudentId" });
            DropIndex("dbo.News", new[] { "IsDeleted" });
            DropIndex("dbo.Rooms", new[] { "IsDeleted" });
            DropIndex("dbo.Rooms", new[] { "FloorId" });
            DropIndex("dbo.Floors", new[] { "IsDeleted" });
            DropIndex("dbo.Floors", new[] { "BuildingId" });
            DropIndex("dbo.ApartmentBuildings", new[] { "IsDeleted" });
            DropColumn("dbo.AspNetUsers", "StudentId");
            DropTable("dbo.Students");
            DropTable("dbo.News");
            DropTable("dbo.Rooms");
            DropTable("dbo.Floors");
            DropTable("dbo.ApartmentBuildings");
        }
    }
}
