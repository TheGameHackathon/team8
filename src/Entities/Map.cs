using System.Numerics;

namespace thegame.Models;

public virtual class 


public class Map
{
    public Map(Vector2 size)
    {
        Size = size;
    }

    public Vector2 Size { get; private set; }

    public Ent
}