using System.Collections.Generic;
using thegame.Domain;

namespace thegame
{
    public class TurnResultDTO
    {
        public List<CardEntity> Map { get; set; }
        public List<CardEntity> ShuffledCards { get; set; }
        public bool IsFinished { get; set; }
    }
}