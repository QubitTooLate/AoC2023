
using System.Text.RegularExpressions;

namespace Qtl.AoC2023.Day02;

public sealed partial class PartTwoSolution01 : ISolution<string[]>
{
	public long Solve(string[] input) =>
		input
			.Select(item =>
				CountAndColor()
					.Matches(item)
					.Select(match => match.Value)
					.Select(countColor => countColor.Split(' '))
					.GroupBy(countColor => countColor[1])
						.Select(countColorGroup => countColorGroup.MaxBy(countColor => int.Parse(countColor[0]))!)
						.Select(countColor => int.Parse(countColor[0]))
					.Aggregate((previous, current) => previous * current))
			.Sum();

	[GeneratedRegex("\\d+ (red|green|blue)")]
	private static partial Regex CountAndColor();
}
