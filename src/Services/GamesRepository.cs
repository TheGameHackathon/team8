using System;
using System.Collections.Generic;

namespace thegame.Services;

public class GamesRepository
{
    private Dictionary<Guid, Game> idToGame = new Dictionary<Guid, Game>();

    public Game GetNewGame(int baseScore)
    {
        var guid = Guid.NewGuid();
        var game = new Game(guid, baseScore);
        idToGame[guid] = game;
        return game;
    }

    public Game GetGameById(Guid guid)
        => idToGame[guid];
}