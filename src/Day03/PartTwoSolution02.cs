
namespace Qtl.AoC2023.Day03;

public sealed class PartTwoSolution02 : ISolution
{
	public long Solve(string[] input) => FindAndAddGearRatios(input);

	private static long FindAndAddGearRatios(string[] input)
	{
		var total = 0L;

		for (var y = 0; y < input.Length; y++)
		{
			var row = input[y];
			for (var x = 0; x < row.Length; x++)
			{
				var character = row[x];

				if (character == '*')
				{
					if (FindSurroundingDigitCoordinates(input, x, y, out var first, out var second))
					{
						var result = MultiplyDigits(input, first, second);
						total += result;
					}
				}
			}
		}

		return total;
	}

	private static long MultiplyDigits(string[] input, (int, int) first, (int, int) second)
	{
		var size = (width: input[0].Length, height: input.Length);

		var total = 1L;
		{
			var (x, y) = first;
			var row = input[y];

			// Find entire number containing digit.
			var lx = x - 1;
			for (; lx > 0 && char.IsAsciiDigit(row[lx]); lx--) ;

			var rx = x + 1;
			for (; rx < size.width && char.IsAsciiDigit(row[rx]); rx++) ;

			var digitsSpan = input[y].AsSpan(lx, rx - lx);
			if (!char.IsAsciiDigit(digitsSpan[0]))
			{
				digitsSpan = digitsSpan[1..];
			}

			var result = int.Parse(digitsSpan);
			total *= result;
		}

		{
			var (x, y) = second;
			var row = input[y];

			// Find entire number containing digit.
			var lx = x - 1;
			for (; lx > 0 && char.IsAsciiDigit(row[lx]); lx--) ;

			var rx = x + 1;
			for (; rx < size.width && char.IsAsciiDigit(row[rx]); rx++) ;

			var digitsSpan = input[y].AsSpan(lx, rx - lx);
			if (!char.IsAsciiDigit(digitsSpan[0]))
			{
				digitsSpan = digitsSpan[1..];
			}

			var result = int.Parse(digitsSpan);
			total *= result;
		}

		return total;
	}

	private static bool FindSurroundingDigitCoordinates(string[] input, int x, int y, out (int, int) first, out (int, int) second)
	{
		first = default;
		second = default;

		var size = (width: input[0].Length, height: input.Length);
		var found = 0;

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

					if (found == 0)
					{
						first = (cx,  cy);
					}
					else if (found == 1)
					{
						second = (cx, cy);
					}
					else
					{
						return false;
					}

					found++;
					alreadyFoundDigit = true;
				}
				else
				{
					alreadyFoundDigit = false;
				}
			}
		}

		return found == 2;
	}
}
