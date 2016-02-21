namespace CampusSystem.Services.Data
{
    using System;
    using System.Linq;
    using CampusSystem.Data.Common;
    using CampusSystem.Data.Models;

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
    }
}
