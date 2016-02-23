namespace CampusSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly INewsService news;

        public HomeController(INewsService news)
        {
            this.news = news;
        }

        public ActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                News = this.news.GetLatestThreeNews().To<NewsViewModel>().ToList()
            };

            return this.View(viewModel);
        }

        public ActionResult About()
        {
            return this.View();
        }

        public ActionResult Contact()
        {
            return this.View();
        }
    }
}