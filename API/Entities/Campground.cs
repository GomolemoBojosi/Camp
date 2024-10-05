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

        public static implicit operator Task<object>(Campground v)
        {
            throw new NotImplementedException();
        }
    }
}
