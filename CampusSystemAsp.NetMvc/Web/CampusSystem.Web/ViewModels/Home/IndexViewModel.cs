namespace CampusSystem.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public ICollection<NewsViewModel> News { get; set; }
    }
}