namespace CampusSystem.Services.Data
{
    using System.Linq;
    using CampusSystem.Data.Models;

    public interface IRoomService
    {
        IQueryable<Room> GetAllFreeRooms(int bedsCount);

        IQueryable<Room> GetFreeRooms(bool hasBalcon);

        IQueryable<Room> GetRooms(int buildingId, int floorId, bool hasBalcon);

        IQueryable<Room> GetRoomsByFloorId(int floorId);

        Room AssignUserFoorRoom(int id, string userId);
    }
}
