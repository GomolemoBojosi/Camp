using API.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ReviewDto
    {
        public int Id { get; set; }
        [Required]
        public string Body { get; set; }
        [Range(1,5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }
        public int CampgroundId { get; set; }
        public int userId { get; set; }
    }
}
