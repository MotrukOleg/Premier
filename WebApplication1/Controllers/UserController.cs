using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Chains;
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserService _userService;

        public UserController(AppDbContext context, UserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Login(UserInputDto input)
        {
             (User? user, string? token) = await _userService.Login(input);

            if (user is null)
            {
                return Unauthorized("User not found");
            }

            return Ok(new {Token = token , User = user});
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegisterDto input)
        {
            User? user = await _userService.Register(input);
            if (user is null)
            {
                return BadRequest("User already exists");
            }
            return CreatedAtAction(nameof(Register), new { id = user.Id }, user);
        }
    }
}
