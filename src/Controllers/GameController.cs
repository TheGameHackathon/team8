using Microsoft.AspNetCore.Mvc;

namespace thegame.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {

        public int[,] Map {get; set;} = new int[4,8];

        [HttpGet("score")]
        public IActionResult Score()
        {
            return Ok(50);
        }

        [HttpGet("start")]
        public IActionResult Start()
        {
            Map = new int[,] {
                {1, 2, 3, 4, 1, 2, 3, 4},
                {5, 6, 7, 8, 5, 6, 7, 8},
                {9, 10, 11, 12, 9, 10, 11, 12},
                {13, 14, 15, 0, 13, 14, 15, 0},      
            };
            return Ok(Map);
        }

        [HttpPost("turn")]
        public IActionResult Turn([FromBody] TurnDTO turn)
        {
            return Ok();
        }
    }

    
}
