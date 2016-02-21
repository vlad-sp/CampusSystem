namespace CampusSystem.Data.Models
{
    using System.Collections.Generic;
    using Common.Models;

    public class Floor : BaseModel<int>
    {
        public Floor()
        {
            this.Rooms = new HashSet<Room>();
        }

        public int FloorNumber { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public int BuildingId { get; set; }

        public virtual ApartmentBuilding Building { get; set; }
    }
}
