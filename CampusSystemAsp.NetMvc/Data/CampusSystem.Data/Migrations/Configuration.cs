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

                var studentList = new List<User>()
                {
                    new User() { UserName = "user1@site.com", Email = "user1@site.com", FirstName = "Ekaterina", LastName = "Trifonova", University = "Technical University", FacultyName = "FKSU", GroupNumber = 1, FacultyNumber = "10", PasswordHash = passwordHash.HashPassword("user1"), SecurityStamp = Guid.NewGuid().ToString() },
                    new User() { UserName = "user2@site.com", Email = "user2@site.com", FirstName = "Milen", LastName = "Radev", University = "Technical University", FacultyName = "FKSU", GroupNumber = 1, FacultyNumber = "11", PasswordHash = passwordHash.HashPassword("user2"), SecurityStamp = Guid.NewGuid().ToString() },
                    new User() { UserName = "user3@site.com", Email = "user3@site.com", FirstName = "Mira", LastName = "Goranova", University = "Technical University", FacultyName = "FKSU", GroupNumber = 2, FacultyNumber = "12", PasswordHash = passwordHash.HashPassword("user3"), SecurityStamp = Guid.NewGuid().ToString() },
                    new User() { UserName = "user4@site.com", Email = "user4@site.com", FirstName = "Yasen", LastName = "Markov", University = "Technical University", FacultyName = "FKSU", GroupNumber = 2, FacultyNumber = "13", PasswordHash = passwordHash.HashPassword("user4"), SecurityStamp = Guid.NewGuid().ToString() },
                    new User() { UserName = "user5@site.com", Email = "user5@site.com", FirstName = "Aleksandar", LastName = "Petrov", University = "Technical University", FacultyName = "FKSU", GroupNumber = 3, FacultyNumber = "14", PasswordHash = passwordHash.HashPassword("user5"), SecurityStamp = Guid.NewGuid().ToString() },
                    new User() { UserName = "user6@site.com", Email = "user6@site.com", FirstName = "Iordan", LastName = "Damyanov", University = "Technical University", FacultyName = "FKSU", GroupNumber = 3, FacultyNumber = "15", PasswordHash = passwordHash.HashPassword("user6"), SecurityStamp = Guid.NewGuid().ToString() },
                    new User() { UserName = "user7@site.com", Email = "user7@site.com", FirstName = "Pavel", LastName = "Borislavov", University = "Technical University", FacultyName = "FKSU", GroupNumber = 4, FacultyNumber = "16", PasswordHash = passwordHash.HashPassword("user7"), SecurityStamp = Guid.NewGuid().ToString() },
                    new User() { UserName = "user8@site.com", Email = "user8@site.com", FirstName = "Anna", LastName = "Apostolova", University = "Technical University", FacultyName = "FKSU", GroupNumber = 4, FacultyNumber = "17", PasswordHash = passwordHash.HashPassword("user8"), SecurityStamp = Guid.NewGuid().ToString() },
                    new User() { UserName = "user9@site.com", Email = "user9@site.com", FirstName = "Vaska", LastName = "Andreeva", University = "Technical University", FacultyName = "FKSU", GroupNumber = 5, FacultyNumber = "18", PasswordHash = passwordHash.HashPassword("user9"), SecurityStamp = Guid.NewGuid().ToString() },
                    new User() { UserName = "user10@site.com", Email = "user10@site.com", FirstName = "Vesela", LastName = "Dragomirova", University = "Technical University", FacultyName = "FKSU", GroupNumber = 5, FacultyNumber = "19", PasswordHash = passwordHash.HashPassword("user10"), SecurityStamp = Guid.NewGuid().ToString() },

                };

                foreach (var student in studentList)
                {
                    userManager.Create(student);
                    userManager.AddToRole(student.Id, "Student");
                }
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

            if (!context.Consumptions.Any())
            {
                var consumptionList = new List<Consumption>()
                {
                    new Consumption() { Month = "September 2016", Electricity = 18, HotWater = 4, ColdWater = 8, RoomId = 5 },
                    new Consumption() { Month = "May 2016", Electricity = 8, HotWater = 3, ColdWater = 12, RoomId = 6 },
                    new Consumption() { Month = "July 2016", Electricity = 22, HotWater = 2.3, ColdWater = 9, RoomId = 7 },
                    new Consumption() { Month = "August 2016", Electricity = 1, HotWater = 4.8, ColdWater = 15, RoomId = 1 },
                    new Consumption() { Month = "June 2016", Electricity = 6, HotWater = 1, ColdWater = 6, RoomId = 2 },
                    new Consumption() { Month = "September 2016", Electricity = 12, HotWater = 9, ColdWater = 10, RoomId = 11 },
                    new Consumption() { Month = "September 2016", Electricity = 19, HotWater = 5.3, ColdWater = 28, RoomId = 18 },
                    new Consumption() { Month = "September 2016", Electricity = 8, HotWater = 2.3, ColdWater = 18, RoomId = 13 },
                    new Consumption() { Month = "September 2016", Electricity = 13, HotWater = 4, ColdWater = 6, RoomId = 9 },
                    new Consumption() { Month = "September 2016", Electricity = 15, HotWater = 7, ColdWater = 8, RoomId = 17 },
                };

                foreach (var consumption in consumptionList)
                {
                    context.Consumptions.Add(consumption);
                }

                context.SaveChanges();
            }
        }
    }
}
