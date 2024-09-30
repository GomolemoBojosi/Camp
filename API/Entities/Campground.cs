namespace API.Entities
{
    public class Campground
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Price { get; set; }
        public String Description { get; set; }
        public String Location { get; set; }

        public static implicit operator Task<object>(Campground v)
        {
            throw new NotImplementedException();
        }
    }
}
