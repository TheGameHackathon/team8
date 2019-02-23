using System;
using System.Collections.Generic;
using System.Linq;

namespace thegame.Domain
{
    public class GameState
    {
        private int foundedPairsCount = 0;
        public List<CardEntity> Map { get; set; } = new List<CardEntity>();
        public int PreviousPosition { get; set; } = -1;
        public int TurnCount { get; set; }
        public int Score { get; set; }
        public int Combo { get; set; }

        public bool IsFinished => foundedPairsCount == 16;

        public void RegenerateMap()
        {
            var random = new Random();
            var elements = new List<CardEntity>();
            for (int i = 0; i < 16; i++)
            {
                elements.Add(new CardEntity {IsFlipped = false, Type = i});
                elements.Add(new CardEntity {IsFlipped = false, Type = i});
            }

            Map = elements.OrderBy(x => random.Next()).ToList();
            PreviousPosition = -1;
            foundedPairsCount = 0;
            TurnCount = 0;
            Score = 0;
            Combo = 1;
        }

        public void MakeTurn(int position)
        {
            Map[position].IsFlipped = true;


            if (TurnCount % 2 != 0)
            {
                if (Map[PreviousPosition].Type == Map[position].Type)
                {
                    foundedPairsCount++;
                    Score += 10 * Combo;
                    Combo++;

                }

                else
                {
                    Map[PreviousPosition].IsFlipped = false;
                    Map[position].IsFlipped = false;
                    Combo = 1;
                    Score -= 2;
                }

                PreviousPosition = -1;
            }
            else
            {
                PreviousPosition = position;
                //result.IsMatch = false;
            }

            TurnCount++;
        }
    }
}