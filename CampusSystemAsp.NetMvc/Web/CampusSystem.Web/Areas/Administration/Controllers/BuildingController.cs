namespace CampusSystem.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
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
        private readonly IConsumptionService consumptions;
        private readonly IRoomService rooms;
        private readonly IFloorService floors;

        private IndexBuildingViewModel viewModel = new IndexBuildingViewModel();

        public BuildingController(IBuildingService buildings, IRoomService rooms, IConsumptionService consumptions, IFloorService floors)
        {
            this.buildings = buildings;
            this.consumptions = consumptions;
            this.floors = floors;
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

        public ActionResult LoadConsumption(int id)
        {
            var rooms = this.floors.GetRoomsByFloorId(id).ToList();
            var model = new ConsumptionStatisticViewModel();
            model.Statistics = new List<ConsumptionViewModel>();
            model.FloorNumber = this.floors.GetFloorNameById(id);

            foreach (var room in rooms)
            {
                var consumption = this.consumptions.GetConsumptionsByRoomId(room.Id).To<ConsumptionViewModel>().FirstOrDefault();
                if (consumption != null)
                {
                    consumption.RoomName = room.RoomName;
                    model.Statistics.Add(consumption);
                }
            }

            return this.PartialView("_ConsumptionInfoPartial", model);
        }

        public ActionResult UpdateHostName(int id, string name)
        {
            this.buildings.UpdateCampusHostName(id, name);
            this.TempData["Notification"] = "Host name changed successfully!";

            return this.RedirectToAction("Index", "Building");
        }
    }
}