namespace API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Campground> Campgrounds { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
