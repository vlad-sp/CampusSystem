namespace CampusSystem.Services.Data
{
    using System;
    using System.Linq;

    using CampusSystem.Data.Common;
    using CampusSystem.Data.Models;

    public class NewsService : INewsService
    {
        private const int LatestNewsCount = 3;

        private readonly IDbRepository<News> news;

        public NewsService(IDbRepository<News> news)
        {
            this.news = news;
        }

        public News CreateNews(News model)
        {
            this.news.Add(model);
            this.news.Save();
            return model;
        }

        public IQueryable<News> GetAll()
        {
            return this.news.All();
        }

        public IQueryable<News> GetLatestThreeNews()
        {
            return this.news.All().OrderByDescending(x => x.CreatedOn).Take(LatestNewsCount);
        }

        public void UpdateNews(News model)
        {
            var news = this.news.GetById(model.Id);
            news.Title = model.Title;
            news.Content = model.Content;
            this.news.Save();
        }
    }
}
