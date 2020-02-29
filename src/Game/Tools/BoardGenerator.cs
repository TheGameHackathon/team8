using System.Collections.Generic;
using System.Drawing;
using thegame.Game.Primitives;

namespace thegame.Game.Tools
{
	public class BoardGenerator
	{
		private static readonly List<Color> Colors = new List<Color> {
			Color.AliceBlue, 
			Color.Black, 
			Color.Blue, 
			Color.BlueViolet, 
			Color.SpringGreen, 
			Color.DarkGoldenrod,
			Color.Brown,
			Color.DeepSkyBlue
		};

		public GameBoard Generate(int height, int width)
		{
			var cards = CreateCards(width, height);

			return new GameBoard(cards);
		}

		private static Card[,] CreateCards(int height, int width)
		{
			var size = height * width;
			var cards = new Card[height,width];
			var colors = GetColors().GetEnumerator();
			colors.MoveNext();

			for (var i = 0; i < height; i++)
			{
				for (var j = 0; j < width; j++)
				{
					colors.MoveNext();
					var color = colors.Current;
					cards[i, j] = new Card(color);
				}
			}

			return cards;
		}

		private static IEnumerable<Color> GetColors()
		{
			var colorsCount = Colors.Count;
			var shift = 0;
			Colors.Shuffle();

			while (true)
			{
				yield return Colors[shift];
				shift = (shift + 1) % colorsCount;
			}
		}
	}
}
