namespace CampusSystem.Data.Models
{
    using CampusSystem.Data.Common.Models;

    public class ConsumptionPrice : BaseModel<int>
    {
        public decimal ElectricityPrice { get; set; }

        public decimal ColdWaterPrice { get; set; }

        public decimal HotWaterPrice { get; set; }

        public decimal HeatingPrice { get; set; }
    }
}
