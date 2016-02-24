namespace CampusSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<CampusSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CampusSystemDbContext context)
        {
            if (!context.Roles.Any())
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var adminRole = new IdentityRole { Name = "Administrator" };
                var studentRole = new IdentityRole { Name = "Student" };

                manager.Create(adminRole);
                manager.Create(studentRole);
            }

            if (!context.Users.Any())
            {
                var passwordHash = new PasswordHasher();
                string password = passwordHash.HashPassword("admin");

                var admin = new User
                {
                    UserName = "admin@site.com",
                    Email = "admin@site.com",
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var userManager = new UserManager<User>(new UserStore<User>(context));

                userManager.Create(admin);
                userManager.AddToRole(admin.Id, "Administrator");
            }

            if (!context.News.Any())
            {
                var newsList = new List<News>()
                {
                    new News() { Title = "News one", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec mollis enim eget semper eleifend. Nullam ultrices bibendum mollis. Sed dui enim, mollis vel sapien at, scelerisque rhoncus sapien. Proin eu sapien ultrices, malesuada turpis nec, dapibus neque. Vivamus consequat mi quis pretium porttitor. Morbi a faucibus leo. Proin hendrerit blandit felis, id suscipit eros finibus sed. Quisque leo enim, tempus sit amet sollicitudin sed, lobortis dignissim ante. Mauris sit amet hendrerit purus." },
                    new News() { Title = "News two", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec mollis enim eget semper eleifend. Nullam ultrices bibendum mollis. Sed dui enim, mollis vel sapien at, scelerisque rhoncus sapien. Proin eu sapien ultrices, malesuada turpis nec, dapibus neque. Vivamus consequat mi quis pretium porttitor. Morbi a faucibus leo. Proin hendrerit blandit felis, id suscipit eros finibus sed. Quisque leo enim, tempus sit amet sollicitudin sed, lobortis dignissim ante. Mauris sit amet hendrerit purus." },
                    new News() { Title = "News three", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec mollis enim eget semper eleifend. Nullam ultrices bibendum mollis. Sed dui enim, mollis vel sapien at, scelerisque rhoncus sapien. Proin eu sapien ultrices, malesuada turpis nec, dapibus neque. Vivamus consequat mi quis pretium porttitor. Morbi a faucibus leo. Proin hendrerit blandit felis, id suscipit eros finibus sed. Quisque leo enim, tempus sit amet sollicitudin sed, lobortis dignissim ante. Mauris sit amet hendrerit purus." },
                    new News() { Title = "News four", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec mollis enim eget semper eleifend. Nullam ultrices bibendum mollis. Sed dui enim, mollis vel sapien at, scelerisque rhoncus sapien. Proin eu sapien ultrices, malesuada turpis nec, dapibus neque. Vivamus consequat mi quis pretium porttitor. Morbi a faucibus leo. Proin hendrerit blandit felis, id suscipit eros finibus sed. Quisque leo enim, tempus sit amet sollicitudin sed, lobortis dignissim ante. Mauris sit amet hendrerit purus." },
                    new News() { Title = "News five", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec mollis enim eget semper eleifend. Nullam ultrices bibendum mollis. Sed dui enim, mollis vel sapien at, scelerisque rhoncus sapien. Proin eu sapien ultrices, malesuada turpis nec, dapibus neque. Vivamus consequat mi quis pretium porttitor. Morbi a faucibus leo. Proin hendrerit blandit felis, id suscipit eros finibus sed. Quisque leo enim, tempus sit amet sollicitudin sed, lobortis dignissim ante. Mauris sit amet hendrerit purus." }
                };

                foreach (var news in newsList)
                {
                    context.News.Add(news);
                }

                context.SaveChanges();
            }

            if (!context.AppartmentBuildings.Any())
            {
                var buildingList = new List<ApartmentBuilding>()
                {
                    new ApartmentBuilding { Name = "Block 11", Address = "Sofia, Student city 11", CampusHostName = "Andrey Smith" },
                    new ApartmentBuilding { Name = "Block 12", Address = "Sofia, Student city 12", CampusHostName = "Jeremy Clarckson" },
                    new ApartmentBuilding { Name = "Block 13", Address = "Sofia, Student city 13", CampusHostName = "James May" }
                };

                foreach (var building in buildingList)
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        building.Floors.Add(new Floor() { FloorNumber = i });
                    }

                    context.AppartmentBuildings.Add(building);
                }

                context.SaveChanges();
            }

            if (!context.Rooms.Any())
            {
                var random = new Random();
                var floors = context.Floors.ToList();

                foreach (var floor in floors)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        floor.Rooms.Add(new Room() { RoomName = $"{floor.Id}{i}", BedsCount = random.Next(1, 5), HasBalcon = false, Area = random.Next(30, 51) });
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
