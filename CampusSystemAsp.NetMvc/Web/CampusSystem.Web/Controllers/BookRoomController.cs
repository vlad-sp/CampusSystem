namespace CampusSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data;
    using ViewModels.BookRoom;
    using Microsoft.AspNet.Identity;
    public class BookRoomController : BaseController
    {
        private readonly IBuildingService buildings;
        private readonly IFloorService floors;
        private readonly IRoomService rooms;
        private IndexBookRoomViewModel viewModel = new IndexBookRoomViewModel();

        public BookRoomController(IBuildingService buildings, IFloorService floors, IRoomService rooms)
        {
            this.buildings = buildings;
            this.floors = floors;
            this.rooms = rooms;
        }

        public ActionResult Index()
        {
            this.viewModel.Buildings = this.buildings.GetAll().ToList();
            return this.View(this.viewModel);
        }

        [HttpPost]
        public ActionResult LoadFloors(int id = 1)
        {
            this.viewModel.Floors = this.floors.GetFloorByBuildingId(id).ToList();
            return this.PartialView("_IndexFloors", this.viewModel);
        }

        [HttpPost]
        public ActionResult LoadRooms(int id = 1)
        {
            this.viewModel.Rooms = this.rooms.GetRoomsByFloorId(id).ToList();
            return this.PartialView("_IndexRooms", this.viewModel);
        }

        [HttpPost]
        public ActionResult BookRoom(int roomId)
        {
            var userId = this.User.Identity.GetUserId();
            var room = this.rooms.AssignUserFoorRoom(roomId, userId);

            return this.View();
        }
    }
}