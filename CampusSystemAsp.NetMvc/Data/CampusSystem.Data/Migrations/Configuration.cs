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
        }
    }
}
