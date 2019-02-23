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
        private readonly GameState GameState;
        

        public GameController(GameState gameState)
        {
            GameState = gameState;
        }

        [HttpGet("score")]
        public IActionResult Score()
        {
            return Ok(50);
        }

        [HttpGet("start")]
        public IActionResult Start()
        {
            GameState.GenerateMap();
            return Ok(GameState.Map);
        }

        [HttpPost("turn")]
        public IActionResult Turn([FromBody] TurnDTO turn)
        {
            #region legacy
            //GameState.Map[turn.Position].IsFlipped = true;
            //var result = new TurnResultDTO
            //{
            //    Position = turn.Position,
            //    IsFlipped = true,
            //    Type = GameState.Map[turn.Position].Type,
            //};



            //if (GameState.TurnCount % 2 != 0)
            //{
            //    result.PreviousPosition = GameState.PreviousPosition;
            //    if (GameState.Map[GameState.PreviousPosition].Type == GameState.Map[turn.Position].Type)
            //    {
            //        result.IsMatch = true;
            //    }

            //    else
            //    {
            //        GameState.Map[GameState.PreviousPosition].IsFlipped = false;
            //        GameState.Map[turn.Position].IsFlipped = false;
            //    }

            //    GameState.PreviousPosition = -1;
            //}
            //else
            //{
            //    result.PreviousPosition = GameState.PreviousPosition;
            //    GameState.PreviousPosition = turn.Position;    
            //    result.IsMatch = false;
            //}
            //GameState.TurnCount++;
#endregion
            GameState.MakeTurn(turn.Position);

            var result = new TurnResultDTO();

            if (GameState.TurnCount % 3 == 0 && GameState.TurnCount != 0)
            {
                var unflippedCards = GameState.Map.Select((c, i) => (c, i)).Where(c => !c.Item1.IsFlipped).ToList();
                if (unflippedCards.Count >= 2)
                {
                    var rnd = new Random();
                    var first = unflippedCards[rnd.Next(0, unflippedCards.Count)];
                    unflippedCards.Remove(first);
                    var second = unflippedCards[rnd.Next(0, unflippedCards.Count)];
                    result.ShuffledCards = new List<CardEntity>()
                    {
                        first.Item1,
                        second.Item1
                    };

                    GameState.Map[first.Item2] = second.Item1;
                    GameState.Map[second.Item2] = first.Item1;
                }

            }
            result.Map = GameState.Map;
            result.IsFinished = GameState.IsFinished;


            return Ok(result);
        }
        
    
    }

    
}
