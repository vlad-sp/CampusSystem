namespace CampusSystem.Web.ViewModels.BookRoom
{
    using System.Collections.Generic;
    using Data.Models;

    public class IndexBookRoomViewModel
    {
        public ICollection<ApartmentBuilding> Buildings { get; set; }

        public ICollection<Floor> Floors { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public User UserInfo { get; set; }
    }
}