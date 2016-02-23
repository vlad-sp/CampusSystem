namespace CampusSystem.Web.Areas.Administration.ViewModels.Building
{
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class FloorBuildingViewModel : IMapFrom<Floor>, IHaveCustomMappings
    {
        public int FloorNumber { get; set; }

        public int RoomsCount { get; set; }

        public int FreeBeds { get; set; }

        public int OccupiedBeds { get; set; }

        public int TotalBeds
        {
            get
            {
                return this.OccupiedBeds + this.FreeBeds;
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Floor, FloorBuildingViewModel>()
                .ForMember(x => x.RoomsCount, opt => opt.MapFrom(f => f.Rooms.Count))
                .ForMember(x => x.FreeBeds, opt => opt.MapFrom(f => f.Rooms.Sum(r => r.FreeBeds)))
                .ForMember(x => x.OccupiedBeds, opt => opt.MapFrom(x => x.Rooms.Sum(r => r.Students.Count)));
        }
    }
}