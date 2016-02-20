namespace CampusSystem.Data.Models
{
    using Common.Models;

    public class Student : BaseModel<int>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string University { get; set; }

        public string FacultyName { get; set; }

        public string FacultyNumber { get; set; }

        public int Course { get; set; }

        public int GroupNumber { get; set; }
    }
}
