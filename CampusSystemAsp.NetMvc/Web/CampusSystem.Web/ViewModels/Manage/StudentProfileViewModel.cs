namespace CampusSystem.Web.ViewModels.Manage
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class StudentProfileViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string University { get; set; }

        public string FacultyName { get; set; }

        public string FacultyNumber { get; set; }

        public int Course { get; set; }

        public int GroupNumber { get; set; }

        public string Email { get; set; }

        public string RoomName { get; set; } = "Not set yet.";

        public int FloorNumber { get; set; }

        public string BuildingName { get; set; } = "Not set yet.";

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Room, StudentProfileViewModel>()
                 .ForMember(x => x.RoomName, opt => opt.MapFrom(r => r.RoomName))
                 .ForMember(x => x.FloorNumber, opt => opt.MapFrom(r => r.Floor.FloorNumber))
                 .ForMember(x => x.BuildingName, opt => opt.MapFrom(r => r.Floor.Building.Name));
        }
    }
}