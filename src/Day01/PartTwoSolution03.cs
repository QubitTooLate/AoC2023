
namespace Qtl.AoC2023.Day01;

public sealed class PartTwoSolution03 : ISolution
{
	// "Single line of code", isn't that funny?
	public long Solve(string[] input) =>
		input
		.Select(item =>
			((new[]
			{
				Enumerable
					.Range(0, 10)
					.Select(i => new
					{
						Value = i,
						Index = item.IndexOf((char)('0' + i))
					})
					.Where(o => o.Index != -1)
					.MinBy(o => o.Index),
				Enumerable
					.Range(1, 9)
					.Select(i => new
					{
						Value = i,
						Index = item.IndexOf((new string[] { string.Empty, "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" })[i])
					})
					.Where(o => o.Index != -1)
					.MinBy(o => o.Index)
			}
				.Where(o => o is { })
				.MinBy(o => o!.Index)!.Value) * 10) +
			(new[]
			{
				Enumerable
					.Range(0, 10)
					.Select(i => new
					{
						Value = i,
						Index = item.LastIndexOf((char)('0' + i))
					})
					.Where(o => o.Index != -1)
					.MaxBy(o => o.Index),
				Enumerable
					.Range(1, 9)
					.Select(i => new
					{
						Value = i,
						Index = item.LastIndexOf((new string[] { string.Empty, "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" })[i])
					})
					.Where(o => o.Index != -1)
					.MaxBy(o => o.Index)
			}
				.Where(o => o is { })
				.MaxBy(o => o!.Index)!.Value)
		).Sum();
}
