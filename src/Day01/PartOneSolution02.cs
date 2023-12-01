namespace Qtl.AoC2023.Day01;

public sealed class PartOneSolution02 : ISolution<string[]>
{
	public long Solve(string[] input) => input.Select(item => (GetFirstNumberFound(item) * 10) + GetLastNumberFound(item)).Sum();

	private static char[] NumberCharacters { get; } = Enumerable.Range('0', 10).Select(i => (char)i).ToArray();

	private static int GetNumberForNumberCharacter(char c) => c - '0';

	private static char GetFirstCharFoundOfAny(string charsToSearchIn, char[] chars) => charsToSearchIn[charsToSearchIn.IndexOfAny(chars)];

	private static char GetLastCharFoundOfAny(string charsToSearchIn, char[] chars) => charsToSearchIn[charsToSearchIn.LastIndexOfAny(chars)];

	private static int GetFirstNumberFound(string charsToSearchIn) => GetNumberForNumberCharacter(GetFirstCharFoundOfAny(charsToSearchIn, NumberCharacters));

	private static int GetLastNumberFound(string charsToSearchIn) => GetNumberForNumberCharacter(GetLastCharFoundOfAny(charsToSearchIn, NumberCharacters));
}
