
namespace Qtl.AoC2023.Day03;

public sealed class PartOneSolution02 : ISolution
{
	private static readonly string _symbols = "*+/-+$#@&%=";

	public long Solve(string[] input) => SearchTroughMatrix(input);

	private static long SearchTroughMatrix(string[] input)
	{
		var size = (width: input[0].Length, height: input.Length);
		var digitCoordinates = FindAllDigitCoordinates(input);

		var total = 0L;
		for (var i = 0; i < digitCoordinates.Count; i++)
		{
			var (x, y) = digitCoordinates[i];
			var row = input[y];

			// Find entire number containing digit.
			var lx = x - 1;
			for (; lx > 0 && char.IsAsciiDigit(row[lx]); lx--);

			var rx = x + 1;
			for (; rx < size.width && char.IsAsciiDigit(row[rx]); rx++);

			var digitsSpan = input[y].AsSpan(lx, rx - lx);
			if (!char.IsAsciiDigit(digitsSpan[0]))
			{
				digitsSpan = digitsSpan[1..];
			}

			var result = int.Parse(digitsSpan);
			total += result;
		}

		return total;
	}

	private static List<(int, int)> FindAllDigitCoordinates(string[] input)
	{
		var foundDigitCoordinates = new List<(int, int)>(2048); // should be enough space without resizing

		for (var y = 0; y < input.Length; y++)
		{
			var row = input[y];
			for (var x = 0; x < row.Length; x++)
			{
				var character = row[x];

				if (_symbols.Contains(character))
				{
					var foundDigitCoordinatesInRow = FindSurroundingDigitCoordinates(input, x, y);
					foundDigitCoordinates.AddRange(foundDigitCoordinatesInRow);

					//Console.WriteLine(string.Join(", ", foundDigitCoordinatesInRow.Select(coordinate => $"({coordinate.Item1}, {coordinate.Item2})")));
				}
			}
		}

		return foundDigitCoordinates;
	}

	private static List<(int, int)>? _foundDigitCoordinates;
	private static List<(int, int)> FindSurroundingDigitCoordinates(string[] input, int x, int y)
	{
		if (_foundDigitCoordinates == null)
		{
			_foundDigitCoordinates = new List<(int, int)>(6); // can never be more than 6
		}
		else
		{
			_foundDigitCoordinates.Clear(); // reusing instead of reallocating
		}

		var size = (width: input[0].Length, height: input.Length);

		for (var cy = Math.Max(y - 1, 0); cy < Math.Min(y + 2, size.height); cy++)
		{
			var alreadyFoundDigit = false;

			for (var cx = Math.Max(x - 1, 0); cx < Math.Min(x + 2, size.width); cx++)
			{
				var subRow = input[cy];
				var subCharacter = subRow[cx];

				if (char.IsAsciiDigit(subCharacter))
				{
					if (alreadyFoundDigit)
					{
						continue;
					}

					_foundDigitCoordinates.Add((cx, cy));
					alreadyFoundDigit = true;
				}
				else
				{
					alreadyFoundDigit = false;
				}
			}
		}

		return _foundDigitCoordinates;
	}
}
