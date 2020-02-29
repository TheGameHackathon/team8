using System.Drawing;

namespace thegame.Game.Primitives
{
	public class Card
	{
		public Card(Color color)
		{
			Color = color;
			Status = CardStatus.UNGUESSED;
		}

		public CardStatus Status { get; set; }
		public Color Color { get; }
	}

	public enum CardStatus
	{
		GUESSED,
		UNGUESSED
	}
}