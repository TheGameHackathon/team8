using System;

namespace Sokoban.Interfaces;

public interface IRepository<T>
{
    public T Get(Guid guid);
    public Tuple<Guid, T> Create(Func<Guid, T> instanciationFunc);
}