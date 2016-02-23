namespace CampusSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;

    using Services.Data.Contracts;
    using ViewModels.BookRoom;

    [Authorize]
    public class BookRoomController : BaseController
    {
        private readonly IBuildingService buildings;
        private readonly IFloorService floors;
        private readonly IRoomService rooms;
        private readonly IStudentService students;

        private IndexBookRoomViewModel viewModel = new IndexBookRoomViewModel();

        public BookRoomController(IBuildingService buildings, IFloorService floors, IRoomService rooms, IStudentService students)
        {
            this.buildings = buildings;
            this.floors = floors;
            this.rooms = rooms;
            this.students = students;
        }

        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            this.viewModel.UserInfo = this.students.GetById(this.User.Identity.GetUserId());
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
            this.viewModel.Rooms = this.rooms.GetFreeRoomsByFloorId(id).ToList();
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