using System;
using System.Collections.Generic;

namespace thegame.Services;

public class GamesRepository
{
    private Dictionary<Guid, Game> idToGame = new Dictionary<Guid, Game>();

    public Game GetNewGame()
    {
        var guid = Guid.NewGuid();
        var game = new Game(guid);
        idToGame[guid] = game;
        return game;
    }

    public Game GetById(Guid guid)
        => idToGame[guid];
}