using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CampgroundDto
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        public string Image { get; set; }
        public string Price { get; set; } 
        public string Description { get; set; }
        public string Location { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; }
        public int UserId { get; set; }
        public ICollection<PhotoDto> Photos { get; set; }
    }
}
