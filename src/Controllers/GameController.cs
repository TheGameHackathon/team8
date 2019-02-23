using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Mvc;
using thegame.Domain;

namespace thegame.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {
        private readonly IGameStateRepository gameStateRepository;


        public GameController(IGameStateRepository gameStateRepository)
        {
            this.gameStateRepository = gameStateRepository;
        }

        [HttpGet("score")]
        public IActionResult Score([FromQuery]Guid id)
        {
            var gameState = gameStateRepository.FindById(id);
            if (gameState == null)
            {
                ModelState.AddModelError("id", "bad id");
                return new UnprocessableEntityObjectResult(ModelState);
            }
            return Ok(gameState.Score);
        }

        [HttpGet("start")]
        public IActionResult Start()
        {
            var id = Guid.NewGuid();
            var gameState = GameState.GenerateNewMap(id);
            gameStateRepository.Insert(gameState);
            return Ok(new StartGameDTO {Id = id, Map = gameState.Map});
        }

        [HttpPost("turn")]
        public IActionResult Turn([FromQuery]Guid id, [FromBody] TurnDTO turn)
        {
            var gameState = gameStateRepository.FindById(id);
            if (gameState == null)
            {
                ModelState.AddModelError("id", "bad id");
                return new UnprocessableEntityObjectResult(ModelState);
            }

            if (turn.Position < 0 || turn.Position >= 32)
            {
                return BadRequest();

            }

            gameState.MakeTurn(turn.Position);

            var result = new TurnResultDTO();

            if (gameState.TurnCount % 3 == 0 && gameState.TurnCount != 0)
            {
                var unflippedCards = gameState.Map.Select((c, i) => (c, i)).Where(c => !c.Item1.IsFlipped).ToList();
                if (unflippedCards.Count >= 2)
                {
                    var rnd = new Random();
                    var first = unflippedCards[rnd.Next(0, unflippedCards.Count)];
                    unflippedCards.Remove(first);
                    var second = unflippedCards[rnd.Next(0, unflippedCards.Count)];
                    result.ShuffledCards = new List<int>()
                    {
                        first.Item2,
                        second.Item2
                    };

                    gameState.Map[first.Item2] = second.Item1;
                    gameState.Map[second.Item2] = first.Item1;
                }
            }

            result.Map = gameState.Map;
            result.IsFinished = gameState.IsFinished;


            return Ok(result);
        }
    }
}