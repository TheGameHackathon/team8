using System;
using System.Collections.Generic;

namespace thegame.Services;

public class GamesRepository
{
    private Dictionary<Guid, Game> idToGame = new Dictionary<Guid, Game>();

    public Game GetNewGame(int baseScore, int levelNumber)
    {
        var guid = Guid.NewGuid();
        var game = new Game(guid, baseScore, levelNumber);
        idToGame[guid] = game;
        return game;
    }

    public Game GetById(Guid guid)
        => idToGame[guid];
}