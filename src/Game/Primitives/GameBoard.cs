namespace thegame.Game.Primitives
{
	public class GameBoard
	{
		public GameBoard(Card[,] cards)
		{
			Cards = cards;
		}

		public Card[,] Cards { get; }
	}
}