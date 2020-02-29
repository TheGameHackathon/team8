using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace thegame
{
    public static class DataBase
    {
        private static Dictionary<int, Game.Game> games;

        private static int counter;

        static DataBase()
        {
            games = new Dictionary<int, Game.Game>();
            counter = -1;
        }

        public static int Add(Game.Game game)
        {
            counter++;
            games.Add(counter, game);
            return counter;
        }

        public static void Delete(int id)
        {
            games.Remove(id);
        }

        public static Game.Game Get(int id)
        {
            return games[id];
        }
    }
}