
namespace Qtl.AoC2023.Day01;

public sealed class PartTwoSolution03 : ISolution<string[]>
{
	// "Single line of code", isn't that funny?
	public long Solve(string[] input) => input.Select(item => ((new[] { Enumerable.Range(0, 10).Select(i => new { Value = i, Index = item.IndexOf((char)('0' + i)) }).Where(o => o.Index != -1).MinBy(o => o.Index), Enumerable.Range(1, 9).Select(i => new { Value = i, Index = item.IndexOf((new string[] { string.Empty, "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" })[i]) }).Where(o => o.Index != -1).MinBy(o => o.Index) }.Where(o => o is { }).MinBy(o => o!.Index)!.Value) * 10) + (new[] { Enumerable.Range(0, 10).Select(i => new { Value = i, Index = item.LastIndexOf((char)('0' + i)) }).Where(o => o.Index != -1).MaxBy(o => o.Index), Enumerable.Range(1, 9).Select(i => new { Value = i, Index = item.LastIndexOf((new string[] { string.Empty, "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" })[i]) }).Where(o => o.Index != -1).MaxBy(o => o.Index) }.Where(o => o is { }).MaxBy(o => o!.Index)!.Value)).Sum();
}

public sealed class PartTwoSolution032 : ISolution<string[]>
{
	public long Solve(string[] input) => 
		input
			.Select(item => 
				((new NumberAtIndex?[] 
				{ 
					GetNumberWithLowestIndex(i => new(i, item.IndexOf((char)('0' + i)))),
					GetNumberWithLowestIndex(i => new(i, item.IndexOf(_numbers[i]))),
				}.Where(o => o is { }).MinBy(o => o!.Index)!.Number) * 10) + 
				(new NumberAtIndex?[]
				{
					GetNumberWithHighestIndex(i => new(i, item.LastIndexOf((char)('0' + i)))),
					GetNumberWithHighestIndex(i => new(i, item.LastIndexOf(_numbers[i]))),
				}.Where(o => o is { }).MaxBy(o => o!.Index)!.Number))
			.Sum();

	private record NumberAtIndex(int Number, int Index);

	private static IEnumerable<NumberAtIndex> GetNumbersWithIndex(Func<int, NumberAtIndex> numberAtIndex) => Enumerable.Range(1, 9).Select(numberAtIndex).Where(o => o.Index != -1);

	private static NumberAtIndex? GetNumberWithHighestIndex(Func<int, NumberAtIndex> numberAtIndex) => GetNumbersWithIndex(numberAtIndex).MaxBy(o => o.Index);

	private static NumberAtIndex? GetNumberWithLowestIndex(Func<int, NumberAtIndex> numberAtIndex) => GetNumbersWithIndex(numberAtIndex).MinBy(o => o.Index);

	private static readonly string[] _numbers = new string[] { string.Empty, "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
}
