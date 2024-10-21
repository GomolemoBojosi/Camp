using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CampgroundDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; }
    }
}
