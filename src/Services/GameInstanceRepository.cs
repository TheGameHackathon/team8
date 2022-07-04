using Sokoban.Interfaces;
using thegame.Services;
using System.Collections.Generic;
using System;

namespace Sokoban.Services;

public class GameInstanceRepository : IRepository<Game>
{
    private Dictionary<Guid, Game> container = new Dictionary<Guid, Game>();

    public Tuple<Guid, Game> Create(Func<Guid, Game> instanciationFunc)
    {
        var guid = Guid.NewGuid();
        var game = instanciationFunc(guid);
        container[guid] = game;
        return new Tuple<Guid, Game>(guid, game);
    }

    public Game Get(Guid guid) => container[guid];
}