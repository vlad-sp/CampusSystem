namespace CampusSystem.Web.Controllers
{
    using System.Web.Mvc;
    using ViewModels.Room;

    public class RoomController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult BookRoom(RoomInputViewModel model)
        {
            return this.View(model);
        }
    }
}