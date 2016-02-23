namespace CampusSystem.Services.Data
{
    using System.Linq;
    using CampusSystem.Data.Common;
    using CampusSystem.Data.Models;
    using Contracts;

    public class BuildingService : IBuildingService
    {
        private readonly IDbRepository<ApartmentBuilding> buildings;

        public BuildingService(IDbRepository<ApartmentBuilding> buildings)
        {
            this.buildings = buildings;
        }

        public IQueryable<ApartmentBuilding> GetAll()
        {
            return this.buildings.All();
        }

        public ApartmentBuilding GetById(int id)
        {
            return this.buildings.GetById(id);
        }

        public IQueryable<Floor> GetFloorsById(int id)
        {
            return this.buildings.GetById(id).Floors.AsQueryable();
        }

        public void UpdateCampusHostName(int id, string name)
        {
            var host = this.buildings.GetById(id);
            host.CampusHostName = name;
            this.buildings.Save();
        }
    }
}
