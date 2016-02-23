namespace CampusSystem.Web.Areas.Administration.ViewModels.Building
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class RoomBuildingViewModel : IMapFrom<Room>, IHaveCustomMappings
    {
        public int OccupiedBeds { get; set; }

        public int FreeBeds { get; set; }

        public int TotalBeds
        {
            get { return this.OccupiedBeds + this.FreeBeds; }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Room, RoomBuildingViewModel>()
                .ForMember(x => x.OccupiedBeds, opt => opt.MapFrom(x => x.Students.Count));

            configuration.CreateMap<Room, RoomBuildingViewModel>()
                .ForMember(x => x.FreeBeds, opt => opt.MapFrom(x => (x.BedsCount - x.Students.Count)));
        }
    }
}