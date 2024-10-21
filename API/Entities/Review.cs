using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Reviews")]
    public class Review
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
        public Campground Campground { get; set; } 
        public int  CampgroundId { get; set; }

    }
}
