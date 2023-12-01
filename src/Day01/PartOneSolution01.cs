namespace Qtl.AoC2023.Day01;

public sealed class PartOneSolution01 : ISolution<string[]>
{
	public long Solve(string[] input)
	{
		var numberCharacters = GetNumberCharacters();

		var total = 0l;
		foreach (var item in input)
		{
			var firstNumberCharacterIndex = item.IndexOfAny(numberCharacters);
			var lastNumberCharacterIndex = item.LastIndexOfAny(numberCharacters);
			var firstNumberCharacter = item[firstNumberCharacterIndex];
			var lastNumberCharacter = item[lastNumberCharacterIndex];
			var firstNumber = GetNumberForNumberCharacter(firstNumberCharacter);
			var lastNumber = GetNumberForNumberCharacter(lastNumberCharacter);
			var number = firstNumber * 10 + lastNumber;
			total += number;
		}

		return total;
	}

	private static char[] GetNumberCharacters() => Enumerable.Range('0', 10).Select(i => (char)i).ToArray();

	private static char GetNumberForNumberCharacter(char c) => (char)(c - '0');
}
