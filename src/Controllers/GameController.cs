using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using thegame.Game;
using thegame.Models;

namespace thegame.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {
        private Game.Game game;
        public GameController()
        {
            this.game = new Game.Game();
        }
        
        [HttpGet("score")]
        public IActionResult Score(int id)
        {
            var score = DataBase.Get(id).GetScore(); ;
            return Ok(score);
        }

        [HttpPost("RollCard")]
        public IActionResult RollCard(int id, CardDTO card)
        {
            //var cardFormGame = games[id].GetCard(card.x, card.y);
            var res = DataBase.Get(id).GetCard(card.x,card.y);
            return Ok(res);
        }

        [HttpGet("GetField")]
        public IActionResult GetField(int id)
        {
            var cards = DataBase.Get(id).Board.Cards;
            return Ok(cards);
        }

        [HttpPost("StartGame")]
        public IActionResult StartGame()
        {
            game = new Game.Game();
            var id = DataBase.Add(game);
            return Ok(id);
        }

        [HttpPost("EndGame")]
        public IActionResult EndGame(int id)
        {
            DataBase.Delete(id);
            return Ok();
        }
    }
}
