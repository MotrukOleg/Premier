using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [EmailAddress] public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}