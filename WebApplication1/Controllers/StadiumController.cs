using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class StadiumController : ControllerBase
    {
        private readonly StadiumService stadium_service;


        public StadiumController(StadiumService stadium_service)
        {
            this.stadium_service = stadium_service;
        }

        [HttpGet]
        public async Task<ActionResult<OutputStadiumDto>> Get()
        {
            List<OutputStadiumDto> stadiums = await stadium_service.Get();

            return Ok(stadiums);
        }


        [HttpGet("GetById")]
        public async Task<ActionResult<OutputStadiumDto>> GetById(int id)
        {
            OutputStadiumDto stadium = await stadium_service.GetById(id);

            return Ok(stadium);
        }

        [HttpPost]
        public async Task<ActionResult<Stadium>> Post(InputStadiumDto input)
        {
            Stadium stadium = await stadium_service.Post(input);

            return CreatedAtAction("GetById", new { id = stadium!.Id }, stadium);
        }
    }
}
