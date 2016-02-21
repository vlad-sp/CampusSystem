namespace CampusSystem.Services.Data
{
    using System.Linq;
    using CampusSystem.Data.Models;

    public interface IBuildingService
    {
        IQueryable<ApartmentBuilding> GetAll();
    }
}
