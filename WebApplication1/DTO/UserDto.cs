using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.DTO
{
    public class UserInputDto
    {
        [EmailAddress] public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class UserRegisterDto
    {
        public string Name { get; set; } = null!;
        [EmailAddress] public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

}
