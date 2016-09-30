namespace CampusSystem.Services.Data
{
    using System;
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

        public int GetFloorNameById(int floorId)
        {
            return this.floors.GetById(floorId).FloorNumber;
        }

        public IQueryable<Room> GetRoomsByFloorId(int floorId)
        {
            return this.floors.GetById(floorId).Rooms.AsQueryable();
        }
    }
}
