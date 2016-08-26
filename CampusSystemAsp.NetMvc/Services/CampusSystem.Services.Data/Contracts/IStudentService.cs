namespace CampusSystem.Services.Data.Contracts
{
    using System.Linq;
    using CampusSystem.Data.Models;

    public interface IStudentService
    {
        IQueryable<User> GetAllStudents();

        User GetById(string id);
    }
}
