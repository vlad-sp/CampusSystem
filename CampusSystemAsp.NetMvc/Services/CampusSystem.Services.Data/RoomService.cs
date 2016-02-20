using System.Linq;
using CampusSystem.Data.Models;
using CampusSystem.Data.Common;

namespace CampusSystem.Services.Data
{
    public class RoomService : IRoomService
    {
        private readonly IDbRepository<Room> rooms;

        public RoomService(IDbRepository<Room> rooms)
        {
            this.rooms = rooms;
        }

        public IQueryable<Room> GetAllFreeRooms(int betsCount)
        {
            return this.rooms.All().Where(x => x.BedsCount >= betsCount);
        }
    }
}
