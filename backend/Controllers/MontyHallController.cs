using backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MontyHallController : ControllerBase
    {
        private readonly IMontyHallService _montyHallService;

        public MontyHallController(IMontyHallService montyHallService)
        {
            _montyHallService = montyHallService;
        }

        [HttpGet]
        [Route("{gameMode}/{gameCount}")]
        public IActionResult Get(int gameMode,int gameCount )
        {
            if(gameMode != 0 && gameMode != 1)
            {
                return BadRequest("Invalid game mode");
            }

            if (gameCount <= 0)
            {
                return BadRequest("Invalid game count");
            }

            return Ok(this._montyHallService.GetWinningChance(gameMode, gameCount));
        }
    }
}
