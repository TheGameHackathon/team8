using System;
using System.Linq;
using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers;

[Route("api/games/{gameId}/moves")]
public class MovesController : Controller
{
    private GamesRepository gamesRepository;

    public MovesController(GamesRepository gamesRepository)
    {
        this.gamesRepository = gamesRepository;
    }

    [HttpPost]
    public IActionResult Moves(Guid gameId, [FromBody]UserInputDto userInput)
    {
        var game = gamesRepository.GetGameById(gameId);
        //
        return Ok(game.GetGameDto());
    }
}