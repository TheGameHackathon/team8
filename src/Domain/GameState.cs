using System.Collections.Generic;

namespace thegame.Domain
{
    public class GameState
    {
        public List<CardEntity> Map { get; set; } = new List<CardEntity>();
        public int PreviousPosition { get; set; } = -1;
        public int TurnCount { get; set; }
    }
}