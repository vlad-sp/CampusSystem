namespace CampusSystem.Web.Areas.Administration.ViewModels.Building
{
    using System.Collections.Generic;
    using Data.Models;

    public class IndexBuildingViewModel
    {
        public ICollection<ApartmentBuilding> Buildings { get; set; }

        public ICollection<FloorBuildingViewModel> Floors { get; set; }

        public BuildingInfoViewModel Info { get; set; }
    }
}