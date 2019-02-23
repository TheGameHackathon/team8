using System;
using System.Collections.Generic;
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
            GameState.Map[turn.Position].IsFlipped = true;
            var result = new TurnResultDTO
            {
                Position = turn.Position,
                IsFlipped = true,
                Type = GameState.Map[turn.Position].Type,
            };

            

            if (GameState.TurnCount % 2 != 0)
            {
                result.PreviousPosition = GameState.PreviousPosition;
                result.IsMatch = GameState.Map[GameState.PreviousPosition].Type == GameState.Map[turn.Position].Type;
                GameState.PreviousPosition = -1;
            }
            else
            {
                result.PreviousPosition = GameState.PreviousPosition;
                GameState.PreviousPosition = turn.Position;    
                result.IsMatch = false;
            }
            GameState.TurnCount++;

            return Ok(GameState.Map);
        }

        //private CardEntity[,] RandomMap()
        //{
        //    var random = new Random();
        //    var elements = new List<CardEntity>();
        //    for (int i = 0;  i < 16;  i++)
        //    {
        //        elements.Add(new CardEntity{IsFlipped = false, Type = i});
        //        elements.Add(new CardEntity { IsFlipped = false, Type = i });
        //    }

        //    elements.Sort((x, y) => random.Next(-1, 1));
        //    var result = new CardEntity[4, 8];
        //    for (var i = 0; i < 8; i++)
        //    {
        //        for (var j = 0; j < 4; j++)
        //        {
                    
        //        }
        //    }
        //}
    
    }

    
}
