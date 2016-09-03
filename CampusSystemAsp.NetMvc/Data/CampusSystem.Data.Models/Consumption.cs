namespace CampusSystem.Data.Models
{
    using Common.Models;

    public class Consumption : BaseModel<int>
    {
        public double Electricity { get; set; }

        public double ColdWater { get; set; }

        public double HotWater { get; set; }

        public double Heating { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}
