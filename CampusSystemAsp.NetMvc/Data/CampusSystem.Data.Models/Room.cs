namespace CampusSystem.Data.Models
{
    using System.Collections.Generic;
    using Common.Models;

    public class Room : BaseModel<int>
    {
        public Room()
        {
            this.Students = new HashSet<User>();
        }

        public string RoomName { get; set; }

        public int BedsCount { get; set; }

        public double Area { get; set; }

        public bool HasBalcon { get; set; }

        public int FreeBeds { get; set; }

        public int FloorId { get; set; }

        public virtual Floor Floor { get; set; }

        public virtual ICollection<User> Students { get; set; }
    }
}
