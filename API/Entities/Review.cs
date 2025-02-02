using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Entities
{
    [Table("Reviews")]
    public class Review
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
        public int  CampgroundId { get; set; }
        public int UserId { get; set; }
    }
}
