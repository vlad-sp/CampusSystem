﻿namespace CampusSystem.Services.Data.Contracts
{
    using System.Linq;
    using CampusSystem.Data.Models;

    public interface INewsService
    {
        IQueryable<News> GetAll();

        IQueryable<News> GetLatestThreeNews();

        News CreateNews(News model);

        void UpdateNews(News model);
    }
}
