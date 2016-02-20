namespace CampusSystem.Data.Models
{
    using Common.Models;

    public class Room : BaseModel<int>
    {
        public int BedsCount { get; set; }

        public double Area { get; set; }

        public bool HasBalcon { get; set; }

        public int FreeBeds { get; set; }

        public int FloorId { get; set; }

        public virtual Floor Floor { get; set; }
    }
}
