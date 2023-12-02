
namespace Qtl.AoC2023.Day01;

public sealed class PartOneSolution03 : ISolution<string[]>
{
	public long Solve(string[] input) => 
		input
			.Select(item =>
				(item.Select(c => c - '0').FirstOrDefault(c => Enumerable.Range(0, 10).Contains(c)) * 10) +
				item.Select(c => c - '0').LastOrDefault(c => Enumerable.Range(0, 10).Contains(c)))
			.Sum();
}
