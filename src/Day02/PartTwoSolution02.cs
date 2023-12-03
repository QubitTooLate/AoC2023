using System.Text.RegularExpressions;

namespace Qtl.AoC2023.Day02;

public sealed partial class PartTwoSolution02 : ISolution
{
	public long Solve(string[] input) =>
		input
			.Select(static item =>
				CountAndColor()
					.Matches(item)
					.Select(static match => new CountColor(match.ValueSpan))
					.GroupBy(static countColor => countColor.Color)
						.Select(static countColorGroup => countColorGroup.MaxBy(static countColor => countColor.Count))
						.Select(static countColor => countColor.Count)
					.Aggregate(static (previousResult, currentCount) => previousResult * currentCount))
			.Sum();

	[GeneratedRegex("\\d+ (red|green|blue)")]
	private static partial Regex CountAndColor();

	private struct CountColor
	{
		public int Count;
		public int Color;

		public CountColor(ReadOnlySpan<char> chars)
		{
			var space = chars.IndexOf(' ');
			Count = int.Parse(chars.Slice(0, space));
			Color = chars[space + 1];
		}
	}
}
