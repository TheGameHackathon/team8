using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thegame.Domain;
using thegame.Models;

namespace thegame.Controllers
{
    [Route("api/scoreboard")]
    [ApiController]
    public class ScoreboardController : ControllerBase
    {
        private readonly IGameStateRepository gameStateRepository;

        public ScoreboardController(IGameStateRepository gameStateRepository)
        {
            this.gameStateRepository = gameStateRepository;
        }

        [HttpGet]
        public IActionResult Scoreboard([FromQuery] int pageNumber = 0, [FromQuery] int pageSize = 5)
        {
            return Ok(gameStateRepository.GetAllGameStates()
                .OrderBy(u => u.Score)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList()
                .Select(s => new ScoreboardElementDTO {Id = s.Id, Scores = s.Score}));

        }

    }
}