namespace CampusSystem.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<CampusSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(CampusSystemDbContext context)
        {
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
