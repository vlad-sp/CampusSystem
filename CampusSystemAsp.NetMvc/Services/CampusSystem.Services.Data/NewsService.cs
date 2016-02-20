namespace CampusSystem.Services.Data
{
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

        public IQueryable<News> GetLatestThreeNews()
        {
            return this.news.All().OrderByDescending(x => x.CreatedOn).Take(LatestNewsCount);
        }
    }
}
