namespace CampusSystem.Services.Data
{
    using System.Linq;
    using CampusSystem.Data.Common;
    using CampusSystem.Data.Models;
    using Contracts;

    public class FloorService : IFloorService
    {
        private IDbRepository<Floor> floors;

        public FloorService(IDbRepository<Floor> floors)
        {
            this.floors = floors;
        }

        public IQueryable<Floor> GetFloorByBuildingId(int buildingId)
        {
            return this.floors.All().Where(x => x.BuildingId == buildingId);
        }
    }
}
