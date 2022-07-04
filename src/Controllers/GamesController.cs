using System;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers;

[Route("api/games")]
public class GamesController : Controller
{
    private GamesRepository gamesRepository;

    public GamesController(GamesRepository gamesRepository)
    {
        this.gamesRepository = gamesRepository;
    }

    [HttpPost]
    public IActionResult Index([FromBody] string levelNumber)
    {
        if (levelNumber == "1")
        {
            var game = gamesRepository.GetNewGame(300);
            var gameDto = game.GetGameDto();
            return Ok(gameDto);
        }

        if (levelNumber == "2")
            throw new NotImplementedException();

        throw new NotSupportedException();
    }
}