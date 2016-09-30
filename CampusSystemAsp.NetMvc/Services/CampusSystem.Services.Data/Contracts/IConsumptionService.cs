namespace CampusSystem.Services.Data.Contracts
{
    using System.Linq;
    using CampusSystem.Data.Models;

    public interface IConsumptionService
    {
        IQueryable<Consumption> GetConsumptionsByRoomId(int roomId);
    }
}
