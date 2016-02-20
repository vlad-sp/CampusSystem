namespace CampusSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Services.Data;
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
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}