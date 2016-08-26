namespace CampusSystem.Data.Models
{
    using System.Collections.Generic;
    using Common.Models;

    public class ApartmentBuilding : BaseModel<int>
    {
        public ApartmentBuilding()
        {
            this.Floors = new HashSet<Floor>();
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public string CampusHostName { get; set; }

        public virtual ICollection<Floor> Floors { get; set; }
    }
}
