using System;
using System.Collections.Generic;
using System.Linq;

namespace thegame.Domain
{
    public class InMemoryGameRepository :IGameStateRepository
    {
        private readonly Dictionary<Guid, GameState> gameStates;

        public InMemoryGameRepository()
        {
            this.gameStates = new Dictionary<Guid, GameState>();
        }


        public void Insert(GameState gameState)
        {
            gameState.Id = gameState.Id;
            gameStates[gameState.Id] = gameState;
        }

        public void Update(GameState gameState)
        {
            if (gameStates.ContainsKey(gameState.Id))
            {
                gameStates[gameState.Id] = gameState;
            }
        }

        public GameState FindById(Guid id)
        {
            if (gameStates.ContainsKey(id))
            {
                return gameStates[id];
            }

            return null;
        }

        public IEnumerable<GameState> GetAllGameStates()
        {
            return gameStates.Values.ToList();
        }
    }
}