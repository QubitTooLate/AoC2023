
namespace Qtl.AoC2023.Day02;

public sealed class PartOneSolution02 : ISolution
{
	public long Solve(string[] input)
	{
		var total = 0L;
		for (var i = 0; i < input.Length; i++)
		{
			if (GameIsValid(input[i], out var id))
			{
				total += id;
			}
		}

		return total;
	}

	private static bool GameIsValid(string input, out int id)
	{
		var inputSpan = input.AsSpan();

		inputSpan = inputSpan[5..];

		var indexOfColon = inputSpan.IndexOf(':');
		var gameIdSpan = inputSpan[0..indexOfColon];
		id = int.Parse(gameIdSpan);

		inputSpan = inputSpan[(indexOfColon + 1)..];

		return AllHandGrabsInGameSpanAreValid(inputSpan);
	}

	private static bool AllHandGrabsInGameSpanAreValid(ReadOnlySpan<char> gameSpan)
	{
		var handGrabRangesBuffer = (Span<Range>)stackalloc Range[10];
		var handGrabRangesCount = SplitSpanIntoRanges(gameSpan, ';', handGrabRangesBuffer);

		for (var i = 0; i < handGrabRangesCount; i++)
		{
			var handGrabSpan = gameSpan[handGrabRangesBuffer[i]];

			if (!AllDiceCollectionsInHandGrabSpanAreValid(handGrabSpan))
			{
				return false;
			}
		}

		return true;
	}

	private static bool AllDiceCollectionsInHandGrabSpanAreValid(ReadOnlySpan<char> handGrabSpan)
	{
		var diceCollectionRangesBuffer = (Span<Range>)stackalloc Range[20];
		var diceCollectionRangesCount = SplitSpanIntoRanges(handGrabSpan, ',', diceCollectionRangesBuffer);

		for (var i = 0; i < diceCollectionRangesCount; i++)
		{
			ParseDiceCollectionSpan(
				GetDiceCollectionSpan(handGrabSpan, diceCollectionRangesBuffer[i]),
				out var count,
				out var colorIndex);

			if (!DiceCollectionIsValid(count, colorIndex))
			{
				return false;
			}
		}

		return true;
	}

	private static ReadOnlySpan<char> GetDiceCollectionSpan(ReadOnlySpan<char> handGrabSpan, Range diceCollectionRange)
	{
		var range = diceCollectionRange;
		range = new Range(range.Start.Value + 1, range.End);

		return handGrabSpan[range];
	}

	private static void ParseDiceCollectionSpan(ReadOnlySpan<char> diceCollectionSpan, out int count, out int colorIndex)
	{
		var colorCountRangesBuffer = (Span<Range>)stackalloc Range[2];
		var colorCountRangesCount = SplitSpanIntoRanges(diceCollectionSpan, ' ', colorCountRangesBuffer);

		count = int.Parse(diceCollectionSpan[colorCountRangesBuffer[0]]);
		colorIndex = IndexOfAnyColor(diceCollectionSpan[colorCountRangesBuffer[1]]);
	}

	private static bool DiceCollectionIsValid(int count, int colorIndex)
	{
		return colorIndex switch
		{
			0 => count <= 12,
			1 => count <= 13,
			2 => count <= 14,
			_ => false
		};
	}

	private static int SplitSpanIntoRanges(ReadOnlySpan<char> spanToSplit, char separator, Span<Range> bufferForRanges)
	{
		var startIndex = 0;
		for (var i = 0; i < bufferForRanges.Length; i++)
		{
			var endIndex = spanToSplit[startIndex..].IndexOf(separator);
			if (endIndex == -1)
			{
				bufferForRanges[i] = new Range(startIndex, spanToSplit.Length);
				return i + 1;
			}

			endIndex += startIndex;
			bufferForRanges[i] = new Range(startIndex, endIndex);
			startIndex = endIndex + 1;
		}

		throw new ArgumentException("Range buffer too small!");
	}

	private static int IndexOfAnyColor(ReadOnlySpan<char> color)
	{
		return color[0] switch
		{
			'r' => 0,
			'g' => 1,
			'b' => 2,
			_ => throw new ArgumentException("Unknown color!")
		};
	}
}
