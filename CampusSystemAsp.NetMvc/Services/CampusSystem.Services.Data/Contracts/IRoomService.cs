namespace CampusSystem.Services.Data.Contracts
{
    using System.Linq;
    using CampusSystem.Data.Models;

    public interface IRoomService
    {
        IQueryable<Room> GetAllFreeRooms(int bedsCount);

        IQueryable<Room> GetFreeRooms(bool hasBalcon);

        IQueryable<Room> GetRooms(int buildingId, int floorId, bool hasBalcon);

        IQueryable<Room> GetRoomsByBuildingId(int buildingId);

        IQueryable<Room> GetFreeRoomsByFloorId(int floorId);

        Room AssignUserFoorRoom(int id, string userId);

        void LeaveRoom(int id, string userId);
    }
}
