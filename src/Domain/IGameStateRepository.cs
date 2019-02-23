using System;

namespace thegame.Domain
{
    public interface IGameStateRepository
    {
        void Insert(GameState gameState);
        void Update(GameState gameState);
        GameState FindById(Guid id);
    }
}