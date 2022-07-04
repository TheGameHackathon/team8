using System.Numerics;

namespace thegame.Models
{
    public interface IUpdatable
    {
        public GameDto UpdateMap(Vector2 move);
    }
}