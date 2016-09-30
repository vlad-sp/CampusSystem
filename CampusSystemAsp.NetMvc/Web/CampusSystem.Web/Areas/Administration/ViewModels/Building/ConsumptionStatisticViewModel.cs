namespace CampusSystem.Web.Areas.Administration.ViewModels.Building
{
    using System.Collections.Generic;

    public class ConsumptionStatisticViewModel
    {
        public ICollection<ConsumptionViewModel> Statistics { get; set; }

        public int FloorNumber { get; set; }
    }
}