using System;
using System.Collections.Generic;
using thegame.Domain;

namespace thegame
{
    public class StartGameDTO
    {
        public Guid Id { get; set; }
        public List<CardEntity> Map { get; set; }
    }
}