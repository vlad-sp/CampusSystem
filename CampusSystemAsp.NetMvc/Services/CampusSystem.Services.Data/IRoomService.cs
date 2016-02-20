using CampusSystem.Data.Models;
using System.Linq;

namespace CampusSystem.Services.Data
{
    public interface IRoomService
    {
        IQueryable<Room> GetAllFreeRooms(int bedsCount);
    }
}
