using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchInfoController : Controller
    {
        private readonly MatchInfoService _matchInfoService;

        public MatchInfoController(MatchInfoService matchInfoService)
        {
            _matchInfoService = matchInfoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MatchInfo>>> Get()
        {
            List<MatchInfo> matches = await _matchInfoService.Get();

            return Ok(matches);
        }

        [HttpGet("GetById/{id}")]

        public async Task<ActionResult<MatchInfo>> GetById(int id)
        {
            MatchInfo match = await _matchInfoService.GetById(id);

            if (match == null)
            {
                return NotFound("There is no such club");
            }

            return Ok(match);
        }

        [HttpGet("GetAllById/{id}")]
        public async Task<ActionResult<List<MatchInfo>>> GetByAllId(int id)
        {
            List<MatchInfo> matches = await _matchInfoService.GetAllById(id);

            if (matches == null)
            {
                return NotFound("There is no such club");
            }

            return Ok(matches);
        }
    }
}