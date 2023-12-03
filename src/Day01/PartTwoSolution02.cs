using System;

namespace Qtl.AoC2023.Day01;

public sealed class PartTwoSolution02 : ISolution
{
	public long Solve(string[] input) =>
		input
			.Select(item => (GetNumber(item, false) * 10) + GetNumber(item, true))
			.Sum();

	private static char[] NumberCharacters { get; } = Enumerable.Range('0', 10).Select(i => (char)i).ToArray();

	private static string[] NumberWords { get; } = new[] { string.Empty, "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

	private static int GetNumberForNumberCharacter(char c) => c - '0';

	private static bool TryFindNumberCharInString(string charsToSearchIn, out int numberFoundAtIndex, out int value, bool startFromTheEnd = false)
	{
		Func<char[], int> indexOfAny = startFromTheEnd ? charsToSearchIn.LastIndexOfAny : charsToSearchIn.IndexOfAny;
		numberFoundAtIndex = indexOfAny(NumberCharacters);
		if (numberFoundAtIndex is -1)
		{
			numberFoundAtIndex = 0;
			value = 0;
			return false;
		}

		var charAtIndex = charsToSearchIn[numberFoundAtIndex];
		value = GetNumberForNumberCharacter(charAtIndex);
		return true;
	}

	private static bool TryFindNumberWordInString(string charsToSearchIn, out int numberFoundAtIndex, out int value, bool startFromTheEnd = false)
	{
		var initialIndex = startFromTheEnd ? int.MinValue : int.MaxValue;
		Func<string, int> indexOf = startFromTheEnd ? charsToSearchIn.LastIndexOf : charsToSearchIn.IndexOf;
		Func<int, int, bool> compare = startFromTheEnd ? IsBigger : IsSmaller;

		numberFoundAtIndex = initialIndex;
		value = 0;
		for (var i = 1; i < NumberWords.Length; i++)
		{
			var currentIndex = indexOf(NumberWords[i]);
			if (currentIndex != -1 && compare(currentIndex, numberFoundAtIndex))
			{
				numberFoundAtIndex = currentIndex;
				value = i;
			}
		}

		return numberFoundAtIndex != initialIndex;
	}

	private static int GetNumber(string charsToSearchIn, bool startFromTheEnd)
	{
		Func<int, int, bool> compare = startFromTheEnd ? IsBigger : IsSmaller;

		var foundAChar = TryFindNumberCharInString(charsToSearchIn, out var indexOfChar, out var valueOfChar, startFromTheEnd);
		var foundAWord = TryFindNumberWordInString(charsToSearchIn, out var indexOfWord, out var valueOfWord, startFromTheEnd);
		if (foundAChar)
		{
			if (foundAWord)
			{
				if (compare(indexOfChar, indexOfWord))
				{
					return valueOfChar;
				}

				return valueOfWord;
			}

			return valueOfChar;
		}

		if (foundAWord)
		{
			return valueOfWord;
		}

		throw new InvalidOperationException("Found nothing!");
	}

	private static bool IsBigger(int a, int b) => a > b;

	private static bool IsSmaller(int a, int b) => a < b;
}
