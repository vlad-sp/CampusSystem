namespace CampusSystem.Services.Data.Contracts
{
    using System.Linq;
    using CampusSystem.Data.Models;

    public interface IFloorService
    {
        IQueryable<Floor> GetFloorByBuildingId(int buildingId);
    }
}
