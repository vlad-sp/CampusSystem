namespace CampusSystem.Services.Data
{
    using System.Linq;
    using CampusSystem.Data.Models;

    public interface INewsService
    {
        IQueryable<News> GetLatestThreeNews();
    }
}
