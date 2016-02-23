namespace CampusSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.News;
    using Web.Controllers;

    [Authorize(Roles = "Administrator")]
    public class NewsController : BaseController
    {
        private readonly INewsService news;

        public NewsController(INewsService news)
        {
            this.news = news;
        }

        public ActionResult Index()
        {
            var viewModel = new IndexNewsViewModel()
            {
                News = this.news.GetAll().To<NewsViewModel>().ToList()
            };

            return this.View(viewModel);
        }

        public ActionResult EditNews(InputNewsViewModel model)
        {
            this.news.UpdateNews(this.Mapper.Map<News>(model));
            this.TempData["EditNews"] = "News edited successfully!";
            return this.RedirectToAction("Index", "Building");
        }

        public ActionResult CreateNews(IndexNewsViewModel model)
        {
            this.news.CreateNews(this.Mapper.Map<News>(model.InputModel));
            return this.RedirectToAction("Index");
        }
    }
}