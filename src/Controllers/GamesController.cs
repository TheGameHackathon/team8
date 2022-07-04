using System;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;
using Sokoban.Interfaces;

namespace thegame.Controllers;

[Route("api/games")]
public class GamesController : Controller
{
    private IRepository<Game> gamesRepository;

    public GamesController(IRepository<Game> gamesRepository)
    {
        this.gamesRepository = gamesRepository;
    }

    [HttpPost]
    public IActionResult Index([FromBody] string levelNumber)
    {
        var game = gamesRepository.Create(guid => new Game(guid, 300, int.Parse(levelNumber)));
        var gameDto = game.Item2.GetGameDto();
        return Ok(gameDto);
    }
}