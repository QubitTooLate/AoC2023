using Qtl.AoC2023;
using Day01 = Qtl.AoC2023.Day01;
using System.Diagnostics;
using System.Text;

PrepareConsole();

RunSolution<Day01.PartOneSolution02, string[]>(
	"""
	1abc2
	pqr3stu8vwx
	a1b2c3d4e5f
	treb7uchet
	""".Split('\n'),
	142, 
	File.ReadAllLines(GetPathForInput(1)),
	54331);

RunSolution<Day01.PartTwoSolution01, string[]>(
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

return;

static void RunSolution<T, TInput>(TInput exampleInput, long expectedExampleResult, TInput input, long? knownResult = null) where T : ISolution<TInput>, new()
{
	{
		var exampleSolution = new T();
		var exampleResult = exampleSolution.Solve(exampleInput);
		if (exampleResult != expectedExampleResult)
		{
			LogError($"❌ Failed with: {exampleResult}, expected: {expectedExampleResult}.");
			return;
		}
	}

	LogSuccess("✔️ Passed example!");

	{
		var solution = new T();
		var timestamp = Stopwatch.GetTimestamp();
		var result = solution.Solve(input);
		var elapsed = Stopwatch.GetElapsedTime(timestamp);
		if (knownResult.HasValue)
		{
			if (result == knownResult.Value)
			{
				LogSuccess($"✔️ Passed real test! Elapsed: {elapsed.TotalMilliseconds}ms");
				return;
			}

			LogError($"❌ Failed with: {result}, expected: {knownResult.Value}.");
			return;
		}

		Log($"❓ Result: {result}, time: {elapsed.TotalMilliseconds}ms");
	}
}

static string GetPathForInput(int day) => 
	Path.Combine($"Day{day:00}", "Input", "Input.txt");

static void PrepareConsole()
{
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
