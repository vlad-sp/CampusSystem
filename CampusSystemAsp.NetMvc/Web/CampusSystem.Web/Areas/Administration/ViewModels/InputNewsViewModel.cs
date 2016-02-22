namespace CampusSystem.Web.Areas.Administration.ViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class InputNewsViewModel : IMapTo<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}