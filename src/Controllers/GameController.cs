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

        public List<CardEntity> Map {get; set;}

        [HttpGet("score")]
        public IActionResult Score()
        {
            return Ok(50);
        }

        [HttpGet("start")]
        public IActionResult Start()
        {
            Map = new List<CardEntity>();

            for (var i = 0; i < 32; i++)
            {
                Map.Add(new CardEntity());
            }

            return Ok(Map);
        }

        [HttpPost("turn")]
        public IActionResult Turn([FromBody] TurnDTO turn)
        {
            Map[turn.Position].IsFlipped = true;
            var result = new TurnResultDTO
            {
                Position =  turn.Position,
                IsFlipped = true
            };
            return Ok(result);
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
