using System.Numerics;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;
using Sokoban.Interfaces;

namespace thegame.Controllers;

[Route("api/games/{gameId}/moves")]
public class MovesController : Controller
{
    private IRepository<Game> gamesRepository;

    public MovesController(IRepository<Game> gamesRepository)
    {
        this.gamesRepository = gamesRepository;
    }

    [HttpPost]
    public IActionResult Moves(Guid gameId, [FromBody] UserInputDto userInput)
    {
        IUpdatable game = gamesRepository.Get(gameId);
        Vector2 vector;
        switch(userInput.KeyPressed)
        {
            case 87: case 38:
                vector = new Vector2(0, -1);
            break;
            case 83: case 40:
                vector = new Vector2(0, 1);
            break;
            case 65: case 37:
                vector = new Vector2(-1, 0);
            break;
            case 68: case 39:
                vector = new Vector2(1, 0);
            break;
            default:
                vector = new Vector2(0, 0);
            break;
        }
        return Ok(game.GetUpdatedMap(vector));
    }
}