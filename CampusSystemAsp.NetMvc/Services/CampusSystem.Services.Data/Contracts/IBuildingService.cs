namespace CampusSystem.Services.Data.Contracts
{
    using System.Linq;
    using CampusSystem.Data.Models;

    public interface IBuildingService
    {
        IQueryable<ApartmentBuilding> GetAll();

        IQueryable<Floor> GetFloorsById(int id);

        ApartmentBuilding GetById(int id);

        void UpdateCampusHostName(int id, string name);
    }
}
