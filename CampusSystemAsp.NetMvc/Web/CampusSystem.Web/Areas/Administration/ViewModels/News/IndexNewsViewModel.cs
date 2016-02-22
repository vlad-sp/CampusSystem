namespace CampusSystem.Web.Areas.Administration.ViewModels.News
{
    using System.Collections.Generic;

    public class IndexNewsViewModel
    {
        public IList<NewsViewModel> News { get; set; }

        public InputNewsViewModel InputModel { get; set; }
    }
}