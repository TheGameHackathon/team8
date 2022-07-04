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
        var game = gamesRepository.GetNewGame(300, int.Parse(levelNumber));
        var gameDto = game.GetGameDto();
        return Ok(gameDto);
    }
}