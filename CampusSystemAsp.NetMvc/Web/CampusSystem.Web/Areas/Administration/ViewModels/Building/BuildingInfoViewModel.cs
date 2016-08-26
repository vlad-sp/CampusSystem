namespace CampusSystem.Web.Areas.Administration.ViewModels.Building
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class BuildingInfoViewModel : IMapFrom<ApartmentBuilding>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [Required]
        [Display(Name = "Campus host name")]
        public string CampusHostName { get; set; }
    }
}