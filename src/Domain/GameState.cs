using System;
using System.Collections.Generic;
using System.Linq;

namespace thegame.Domain
{
    public class GameState
    {
        public List<CardEntity> Map { get; set; } = new List<CardEntity>();
        public int PreviousPosition { get; set; } = -1;
        public int TurnCount { get; set; }

        public void GenerateMap()
        {
            var random = new Random();
            var elements = new List<CardEntity>();
            for (int i = 0;  i < 16;  i++)
            {
                elements.Add(new CardEntity{IsFlipped = false, Type = i});
                elements.Add(new CardEntity { IsFlipped = false, Type = i });
            }
            Map = elements.OrderBy(x => random.Next()).ToList();
            PreviousPosition = -1;

        }
    }
}