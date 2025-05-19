using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        public readonly IClubService club_service;
        public ClubController(IClubService club_service)
        {
            this.club_service = club_service;
        }

        [HttpGet]
        public async Task<ActionResult<List<OutputClubDto>>> Get()
        {
            List<OutputClubDto> clubs = await club_service.Get();
            return Ok(clubs);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<OutputClubDto>> GetById(int id)
        {
            OutputClubDto club = await club_service.GetById(id);

            return Ok(club);
        }

        [HttpPost]
        public async Task<ActionResult<OutputClubDto>> Post(InputClubDto input)
        {
            if (input == null)
            {
                return BadRequest();
            }
            OutputClubDto club = await club_service.Post(input);

            return CreatedAtAction("GetById", new { Id = club!.Id }, club);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<OutputClubDto>> Put(InputClubForWeb input, int id)
        {

            OutputClubDto? clubToUpdate = await club_service.Put(input , id);
            if(clubToUpdate == null)
            {
                return NotFound();    
            }

            return Ok(clubToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Club>> Delete(int id)
        {
            var clubToDelete = await club_service.Delete(id);
            if (clubToDelete != null)
            {
                return Ok();
            }

            return NotFound("Club does not found");
        }

        [HttpGet("GetOldestClub")]

        public async Task<ActionResult<OutputClubDto>> GetOldestClub()
        {
            var oldestClub = await club_service.GetOldestClub();

            if (oldestClub != null)
            {
                return Ok(oldestClub);
            }

            return NotFound();
        }
    }
}
