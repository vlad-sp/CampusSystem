namespace CampusSystem.Data.Models
{
    using Common.Models;

    public class News : BaseModel<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
