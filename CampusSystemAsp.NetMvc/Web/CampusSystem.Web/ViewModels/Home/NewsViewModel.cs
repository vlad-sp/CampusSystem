namespace CampusSystem.Web.ViewModels.Home
{
    using System;

    using Data.Models;
    using Infrastructure.Mapping;

    public class NewsViewModel : IMapFrom<News>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}