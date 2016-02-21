namespace CampusSystem.Services.Data
{
    using System;
    using System.Linq;
    using CampusSystem.Data.Common;
    using CampusSystem.Data.Models;

    public class RoomService : IRoomService
    {
        private readonly IDbRepository<Room> rooms;
        private readonly IDbRepository<Floor> floors;


        public RoomService(IDbRepository<Room> rooms, IDbRepository<Floor> floors)
        {
            this.rooms = rooms;
            this.floors = floors;
        }

        public IQueryable<Room> GetAllFreeRooms(int betsCount)
        {
            return this.rooms.All().Where(x => x.BedsCount >= betsCount);
        }

        public IQueryable<Room> GetFreeRooms(bool hasBalcon)
        {
            return this.rooms.All().Where(x => x.HasBalcon == hasBalcon);
        }

        public IQueryable<Room> GetRooms(int buildingId, int floorId, bool hasBalcon)
        {
            var floorsResult = this.floors.All().Where(x => x.BuildingId == buildingId);
            return this.rooms.All().Where(x => x.FloorId == floorId && x.HasBalcon == hasBalcon);
        }

        public IQueryable<Room> GetRoomsByFloorId(int floorId)
        {
            return this.rooms.All().Where(x => x.FloorId == floorId);
        }

        public Room AssignUserFoorRoom(int id, string userId)
        {
            var room = this.rooms.GetById(id);
            room.UserId = userId;
            this.rooms.Save();
            return room;
        }
    }
}
