using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CampgroundDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Image { get; set; }
        [Required]
        public string Price { get; set; } 
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; }
        public int UserId { get; set; }
        public IFormFile File { get; set; }
    }
}
