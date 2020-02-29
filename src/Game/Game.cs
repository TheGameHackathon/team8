using System;
using System.Linq;
using thegame.Game.Primitives;
using thegame.Game.Tools;

namespace thegame.Game
{
	public class Game
	{
		public GameBoard Board { get; }
		public GameState State { get; private set; }
		public bool IsTranspositionStep => stepCount == 2;
		public Card[] TranspositionCards { get; } = new Card[2];

		private IPlayer player;
		private Card openCard;
		private int stepCount;


		public Game()
		{
			player = null;
			State = GameState.IN_PROCESS;
			var generator = new BoardGenerator();
			Board = generator.Generate(Constants.HeightBoard, Constants.WidthBoard);
			stepCount = 0;
		}

		public Game(IPlayer player)
		{
			this.player = player;
			State = GameState.IN_PROCESS;
			var generator = new BoardGenerator();
			Board = generator.Generate(4, 4);
			stepCount = 0;
		}

		public Card GetCard(int height, int width)
		{
			var card = Board.Cards[height, width];

			CheckMatch(card);
			stepCount = (stepCount + 1) % 3;
			if (stepCount == 2)
				Swap();

			return card;
		}

		public int GetScore()
		{
			return GetCountOfCardsGuessed() * 100;
		}

		private void Swap()
		{
			var rand = new Random();
			var y1 = rand.Next(Constants.HeightBoard - 1);
			var x1 = rand.Next(Constants.WidthBoard - 1);
			var y2 = rand.Next(Constants.HeightBoard - 1);
			var x2 = rand.Next(Constants.WidthBoard - 1);

			var temp = Board.Cards[y1, x1];
			Board.Cards[y1, x1] = Board.Cards[y2, x2];
			Board.Cards[y2, x2] = temp;

			TranspositionCards[0] = Board.Cards[y1, x1];
			TranspositionCards[1] = temp;
		}

		private void CheckMatch(Card card)
		{
			if (openCard == null)
			{
				openCard = card;
			}
			else if (IsPair(card))
			{
				openCard.Status = CardStatus.GUESSED;
				card.Status = CardStatus.GUESSED;
				openCard = null;
				UpdateGameState();
			}
			else
			{
				openCard = null;
			}
		}

		private void UpdateGameState()
		{
			var count = GetCountOfCardsGuessed();

			if (count == Board.Cards.Length)
			{
				State = GameState.FINISHED;
			}
		}

		private bool IsPair(Card card)
		{
			if (openCard == null)
				return false;

			return openCard.Color == card.Color;
		}

		private int GetCountOfCardsGuessed()
		{
			return Board.Cards.Cast<Card>().Count(card => card.Status == CardStatus.GUESSED);
		}
	}
}
