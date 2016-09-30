namespace CampusSystem.Services.Data
{
    using System;
    using System.Linq;
    using CampusSystem.Data.Common;
    using CampusSystem.Data.Models;
    using CampusSystem.Services.Data.Contracts;

    public class ConsumptionService : IConsumptionService
    {
        private readonly IDbRepository<Consumption> consumptions;

        public ConsumptionService(IDbRepository<Consumption> consumptions)
        {
            this.consumptions = consumptions;
        }

        public IQueryable<Consumption> GetConsumptionsByRoomId(int roomId)
        {
            return this.consumptions.All().Where(x => x.RoomId == roomId).OrderByDescending(x => x.Month);
        }
    }
}
