using Qtl.AoC2023;
using Day01 = Qtl.AoC2023.Day01;
using Day02 = Qtl.AoC2023.Day02;
using Day03 = Qtl.AoC2023.Day03;
using System.Diagnostics;
using System.Text;

PrepareConsole();

RunSolution<Day01.PartOneSolution03>(
	"""
	1abc2
	pqr3stu8vwx
	a1b2c3d4e5f
	treb7uchet
	""".Split('\n'),
	142, 
	File.ReadAllLines(GetPathForInput(1)),
	54331);

RunSolution<Day01.PartTwoSolution04>(
	"""
	two1nine
	eightwothree
	abcone2threexyz
	xtwone3four
	4nineeightseven2
	zoneight234
	7pqrstsixteen
	""".Split('\n'),
	281,
	File.ReadAllLines(GetPathForInput(1)),
	54518);

RunSolution<Day02.PartOneSolution02>(
	"""
	Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
	Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
	Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
	Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
	Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
	""".Split('\n'),
	8,
	File.ReadAllLines(GetPathForInput(2)),
	2406);

RunSolution<Day02.PartTwoSolution02>(
	"""
	Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
	Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
	Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
	Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
	Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
	""".Split('\n'),
	2286,
	File.ReadAllLines(GetPathForInput(2)),
	78375);

RunSolution<Day03.PartOneSolution02>(
	"""
	467..114..
	...*......
	..35..633.
	......#...
	617*......
	.....+.58.
	..592.....
	......755.
	...$.*....
	.664.598..
	""".Split('\n'),
	4361,
	File.ReadAllLines(GetPathForInput(3)),
	530849);

RunSolution<Day03.PartTwoSolution02>(
	"""
	467..114..
	...*......
	..35..633.
	......#...
	617*......
	.....+.58.
	..592.....
	......755.
	...$.*....
	.664.598..
	""".Split('\n'),
	467835,
	File.ReadAllLines(GetPathForInput(3)),
	84900879);

return;

static void RunSolution<T>(string[] exampleInput, long expectedExampleResult, string[] input, long? knownResult = null) where T : ISolution, new()
{
	{
		var exampleSolution = new T();
		var exampleResult = exampleSolution.Solve(exampleInput);
		if (exampleResult != expectedExampleResult)
		{
			LogError($"❌ [{typeof(T).FullName}] Failed with: {exampleResult}, expected: {expectedExampleResult}.");
			Pad();
			return;
		}
	}

	LogSuccess($"✔️ [{typeof(T).FullName}] Passed example!");

	{
		var solution = new T();
		var timestamp = Stopwatch.GetTimestamp();
		var result = solution.Solve(input);
		var elapsed = Stopwatch.GetElapsedTime(timestamp);
		if (knownResult.HasValue)
		{
			if (result == knownResult.Value)
			{
				LogSuccess($"✔️ [{typeof(T).FullName}] Passed real test! Elapsed: {elapsed.TotalMilliseconds}ms.");
				Pad();
				return;
			}

			LogError($"❌ [{typeof(T).FullName}] Failed with: {result}, expected: {knownResult.Value}, time: {elapsed.TotalMilliseconds}ms.");
			Pad();
			return;
		}

		Log($"❓ [{typeof(T).FullName}] Result: {result}, time: {elapsed.TotalMilliseconds}ms.");
	}

	Pad();
}

static string GetPathForInput(int day) => 
	Path.Combine($"Day{day:00}", "Input", "Input.txt");

static void PrepareConsole()
{
	Console.Clear();
	Console.OutputEncoding = Encoding.UTF8;
	Console.ForegroundColor = ConsoleColor.White;
}

static void LogError(string message)
{
	Console.ForegroundColor = ConsoleColor.Red;
	Console.WriteLine(message);
	Console.ForegroundColor = ConsoleColor.White;
}

static void LogSuccess(string message)
{
	Console.ForegroundColor = ConsoleColor.Green;
	Console.WriteLine(message);
	Console.ForegroundColor = ConsoleColor.White;
}

static void Log(string message) => Console.WriteLine(message);

static void Pad() => Console.WriteLine();
