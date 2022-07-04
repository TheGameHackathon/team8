using System.Numerics;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers;

[Route("api/games/{gameId}/moves")]
public class MovesController : Controller
{
    public Vector2 playerCoords = new Vector2(1, 1);

    [HttpPost]
    public IActionResult Moves(Guid gameId, [FromBody] UserInputDto userInput)
    {
        var game = TestData.AGameDto(new VectorDto {X = 1, Y = 1});
        //if (userInput.ClickedPos != null)
        //    game.Cells.First(c => c.Type == "color4").Pos = userInput.ClickedPos;
        switch(userInput.KeyPressed)
        {
            case 87: case 38:
                Console.WriteLine("UP");
            break;
            case 83: case 40:
                Console.WriteLine("DOWN");
            break;
            case 65: case 37:
                Console.WriteLine("LEFT");
            break;
            case 68: case 39:
                Console.WriteLine("RIGHT");
            break;
        }
        return Ok(game);
    }
}