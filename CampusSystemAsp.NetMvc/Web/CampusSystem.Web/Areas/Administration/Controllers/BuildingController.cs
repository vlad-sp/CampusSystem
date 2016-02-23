namespace CampusSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Building;
    using Web.Controllers;

    [Authorize(Roles = "Administrator")]
    public class BuildingController : BaseController
    {
        private readonly IBuildingService buildings;
        private readonly IRoomService rooms;

        private IndexBuildingViewModel viewModel = new IndexBuildingViewModel();

        public BuildingController(IBuildingService buildings, IRoomService rooms)
        {
            this.buildings = buildings;
            this.rooms = rooms;
        }

        public ActionResult Index()
        {
            this.viewModel.Buildings = this.buildings.GetAll().ToList();
            return this.View(this.viewModel);
        }

        public ActionResult LoadBuildingInfo(int id)
        {
            var building = this.buildings.GetById(id);
            this.viewModel.Info = this.Mapper.Map<BuildingInfoViewModel>(building);
            var floors = this.buildings.GetFloorsById(id).To<FloorBuildingViewModel>().ToList();
            this.viewModel.Floors = floors;
            return this.PartialView("_BuildingInfoPartial", this.viewModel);
        }

        public ActionResult UpdateHostName(int id, string name)
        {
            this.buildings.UpdateCampusHostName(id, name);
            this.TempData["Notification"] = "Host name changed successfully!";

            return this.RedirectToAction("Index", "Building");
        }
    }
}