using System.Numerics;

namespace thegame.Models
{
    public interface IUpdatable
    {
        public GameDto GetUpdatedMap(Vector2 move);
    }
}