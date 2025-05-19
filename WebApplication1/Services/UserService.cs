using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Chains;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public UserService(AppDbContext context , IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<User?> Register(UserRegisterDto input)
        {

            User? possibleUser = await _context.User.FirstOrDefaultAsync(u => u.Email == input.Email);
            if (possibleUser != null)
            {
                return null;
            }

            var user = new User
            {
                Name = input.Name,
                Email = input.Email,
                Password = input.Password
            };
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<(User? , string?)> Login(UserInputDto input)
        {
            var user = await _context.User.FirstOrDefaultAsync(u =>
                u.Email == input.Email && u.Password == input.Password);

            if (user is null)
            {
                return (null , null);
            }

            var token = GenerateToken(user);
            return (user , token);

        }

        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"] ?? string.Empty));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                expires: DateTime.Now.AddMinutes(30),
                claims: claims,
                signingCredentials: credential
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
