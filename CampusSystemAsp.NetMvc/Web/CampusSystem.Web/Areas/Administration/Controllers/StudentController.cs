namespace CampusSystem.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data;

    public class StudentController : Controller
    {
        private const string EmptyValue = "Not set yet";
        private readonly IStudentService students;


        public StudentController(IStudentService students)
        {
            this.students = students;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult LoadGrid()
        {
            var result = this.students.GetAllStudents().ToList();

            var jsonData = new
            {
                total = 1,
                page = 1,
                records = result.Count,
                rows = (
                        from item in result
                        select new
                        {
                            id = item.Id,
                            cell = new string[]
                            {
                                item.FirstName,
                                item.LastName,
                                item.Course.ToString(),
                                item.GroupNumber.ToString(),
                                item.FacultyName,
                                item.Room?.RoomName,
                                item.Room?.Floor.FloorNumber.ToString(),
                                item.Room?.Floor.Building.Name
                             }
                        }).ToArray()
            };

            return this.Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}