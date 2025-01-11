using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
