namespace API.Entities
{
    public class Campground
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Price { get; set; } 
        public string Description { get; set; }
        public string Location { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Photo> Photos { get; set; } = new List<Photo>();
    }
}
