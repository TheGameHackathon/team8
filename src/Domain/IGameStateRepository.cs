using System;
using System.Collections;
using System.Collections.Generic;

namespace thegame.Domain
{
    public interface IGameStateRepository
    {
        void Insert(GameState gameState);
        void Update(GameState gameState);
        GameState FindById(Guid id);
        IEnumerable<GameState> GetAllGameStates();
    }
}