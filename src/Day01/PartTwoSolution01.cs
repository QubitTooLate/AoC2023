using System;

namespace Qtl.AoC2023.Day01;

public sealed class PartTwoSolution01 : ISolution<string[]>
{
	public long Solve(string[] input) => 
		input
			.Select(item => (GetFirstNumberFound(item, out var firstIndex) * 10) + GetLastNumberFound(item, out var lastIndex))
			.Sum();

	private static char[] NumberCharacters { get; } = Enumerable.Range('0', 10).Select(i => (char)i).ToArray();

	private static string[] NumberWords { get; } = new[]
	{
		"one",
		"two",
		"three",
		"four",
		"five",
		"six",
		"seven",
		"eight",
		"nine"
	};

	private static int GetNumberForNumberCharacter(char c) => c - '0';

	private static bool TryGetIndexesOfFirstCharFoundOfAny(string charsToSearchIn, char[] chars, out int index, out int indexOfFoundChar)
	{
		index = charsToSearchIn.IndexOfAny(chars);
		if (index is -1)
		{
			index = 0;
			indexOfFoundChar = 0;
			return false;
		}

		var charAtIndex = charsToSearchIn[index];
		indexOfFoundChar = GetNumberForNumberCharacter(charAtIndex);
		return true;
	}

	private static bool TryGetIndexesOfLastCharFoundOfAny(string charsToSearchIn, char[] chars, out int index, out int indexOfFoundChar)
	{
		index = charsToSearchIn.LastIndexOfAny(chars);
		if (index is -1)
		{
			index = 0;
			indexOfFoundChar = 0;
			return false;
		}

		var charAtIndex = charsToSearchIn[index];
		indexOfFoundChar = GetNumberForNumberCharacter(charAtIndex);
		return true;
	}

	private static bool TryGetIndexesOfFirstWordFoundOfAny(string textToSearchIn, string[] words, out int index, out int indexOfFoundWord)
	{
		const int InitialIndex = int.MaxValue;

		index = InitialIndex;
		var indexOfWordWithSmallestIndex = 0;
		for (var i = 0; i < words.Length; i++)
		{
			var currentIndex = textToSearchIn.IndexOf(words[i]);
			if (currentIndex != -1 && currentIndex < index)
			{
				index = currentIndex;
				indexOfWordWithSmallestIndex = i;
			}
		}

		indexOfFoundWord = indexOfWordWithSmallestIndex;
		return index != InitialIndex;
	}

	private static bool TryGetIndexesOfLastWordFoundOfAny(string textToSearchIn, string[] words, out int index, out int indexOfFoundWord)
	{
		const int InitialIndex = int.MinValue;

		index = int.MinValue;
		var indexOfWordWithBiggestIndex = 0;
		for (var i = 0; i < words.Length; i++)
		{
			var currentIndex = textToSearchIn.LastIndexOf(words[i]);
			if (currentIndex != -1 && currentIndex > index)
			{
				index = currentIndex;
				indexOfWordWithBiggestIndex = i;
			}
		}

		indexOfFoundWord = indexOfWordWithBiggestIndex;
		return index != InitialIndex;
	}

	private static int GetFirstNumberFound(string charsToSearchIn, out int index)
	{
		var foundChar = TryGetIndexesOfFirstCharFoundOfAny(charsToSearchIn, NumberCharacters, out var charIndex, out int indexOfFoundChar);
		var foundWord = TryGetIndexesOfFirstWordFoundOfAny(charsToSearchIn, NumberWords, out var wordIndex, out var indexOfFoundWord);
		if (foundChar)
		{
			if (foundWord)
			{
				if (charIndex < wordIndex)
				{
					index = charIndex;
					return indexOfFoundChar;
				}

				index = wordIndex;
				return indexOfFoundWord + 1;
			}

			index = charIndex;
			return indexOfFoundChar;
		}

		if (foundWord)
		{
			index = wordIndex;
			return indexOfFoundWord + 1;
		}

		throw new InvalidOperationException("Found nothing!");
	}

	private static int GetLastNumberFound(string charsToSearchIn, out int index)
	{
		var foundChar = TryGetIndexesOfLastCharFoundOfAny(charsToSearchIn, NumberCharacters, out var charIndex, out int indexOfFoundChar);
		var foundWord = TryGetIndexesOfLastWordFoundOfAny(charsToSearchIn, NumberWords, out var wordIndex, out var indexOfFoundWord);
		if (foundChar)
		{
			if (foundWord)
			{
				if (charIndex > wordIndex)
				{
					index = charIndex;
					return indexOfFoundChar;
				}

				index = wordIndex;
				return indexOfFoundWord + 1; // adding 1 to turn the index into the value of the word at that index
			}

			index = charIndex;
			return indexOfFoundChar;
		}

		if (foundWord)
		{
			index = wordIndex;
			return indexOfFoundWord + 1;
		}

		throw new InvalidOperationException("Found nothing!");
	}
}
