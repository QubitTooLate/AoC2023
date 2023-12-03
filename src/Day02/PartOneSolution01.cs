
namespace Qtl.AoC2023.Day02;

public sealed class PartOneSolution01 : ISolution
{
	public long Solve(string[] input) =>
		input
			.Select(ParseGame)
			.Where(GameHasCorrectAmoutOfDice)
			.Sum(game => game.Id);

	private record Game(int Id, HandGrab[] HandGrabs)
	{
		public override string ToString() => $"Id: {Id}, HandGrabs: [{string.Join("] [", HandGrabs.Select(handGrab => handGrab.ToString()))}]";
	}

	private record HandGrab(DiceCollection[] DiceCollections)
	{
		public override string ToString() => string.Join(" ", DiceCollections.Select(diceCollection => diceCollection.ToString()));
	}

	private record DiceCollection(int Count, Color Color)
	{
		public override string ToString() => $"({Count} {Color})";
	}

	private enum Color
	{
		Red,
		Green,
		Blue,
	}

	private static readonly string[] _colors = Enum.GetNames<Color>().Select(name => name.ToLower()).ToArray();

	private static Game ParseGame(string input)
	{
		var inputSpan = input.AsSpan();

		// Cut off "Game ".
		inputSpan = inputSpan[5..];

		// the input span starts now with a number followed by a colon.
		// By creating a span from the start to the index of the colon
		// we get a span over the number that can be parsed to get the
		// value.
		var indexOfColon = inputSpan.IndexOf(':');
		var gameIdSpan = inputSpan[0..indexOfColon];
		var gameId = int.Parse(gameIdSpan);

		// Cut off number and colon.
		inputSpan = inputSpan[(indexOfColon + 1)..];

		// The input span now contains hand grabs split by semi colons.
		var handGrabRangesBuffer = (Span<Range>)stackalloc Range[10];
		var handGrabRangesCount = SplitSpanIntoRanges(inputSpan, ';', handGrabRangesBuffer);

		var game = new Game(gameId, new HandGrab[handGrabRangesCount]);

		var diceCollectionRangesBuffer = (Span<Range>)stackalloc Range[20];
		var colorCountRangesBuffer = (Span<Range>)stackalloc Range[2];
		for (var i = 0; i < handGrabRangesCount; i++)
		{
			// A hand grab span contains dice collections split by commas.
			var handGrabSpan = inputSpan[handGrabRangesBuffer[i]];
			var diceCollectionRangesCount = SplitSpanIntoRanges(handGrabSpan, ',', diceCollectionRangesBuffer);
			// PrintRanges(handGrabSpan, diceCollectionRangesBuffer[..diceCollectionRangesCount]);
			var handGrab = new HandGrab(new DiceCollection[diceCollectionRangesCount]);

			for (var j = 0; j < diceCollectionRangesCount; j++)
			{
				// Cut off the space at the start.
				var range = diceCollectionRangesBuffer[j];
				range = new Range(range.Start.Value + 1, range.End);

				// A dice collection is a count and color split by spaces.
				var diceCollectionSpan = handGrabSpan[range];
				var colorCountRangesCount = SplitSpanIntoRanges(diceCollectionSpan, ' ', colorCountRangesBuffer);
				// PrintRanges(diceCollectionSpan, colorCountRangesBuffer[..colorCountRangesCount]);

				var count = int.Parse(diceCollectionSpan[colorCountRangesBuffer[0]]);
				var color = ParseColor(diceCollectionSpan[colorCountRangesBuffer[1]]);

				var diceCollection = new DiceCollection(count, color);

				handGrab.DiceCollections[j] = diceCollection;
			}

			game.HandGrabs[i] = handGrab;
		}

		return game;
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

	private static void PrintRanges(ReadOnlySpan<char> span, Span<Range> ranges)
	{
		for (var i = 0; i < ranges.Length; i++)
		{
			Console.WriteLine(new string(span[ranges[i]]).Replace(' ', '_'));
		}
	}

	private static Color ParseColor(ReadOnlySpan<char> color)
	{
		for (var i = 0; i < _colors.Length; i++)
		{
			var colorSpan = _colors[i].AsSpan();
			if (color.IndexOf(colorSpan) != -1)
			{
				return (Color)i;
			}
		}

		return default;
	}

	private static bool GameHasCorrectAmoutOfDice(Game game) => !game.HandGrabs
		.Any(handGrab => handGrab.DiceCollections
			.Any(diceCollection => diceCollection switch
			{
				{ Color: Color.Red, Count: > 12 } => true,
				{ Color: Color.Green, Count: > 13 } => true,
				{ Color: Color.Blue, Count: > 14 } => true,
				_ => false
			}));
}
