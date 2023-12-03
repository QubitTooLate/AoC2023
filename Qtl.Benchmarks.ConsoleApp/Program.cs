using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using Day01 = Qtl.AoC2023.Day01;
using Day02 = Qtl.AoC2023.Day02;
using Day03 = Qtl.AoC2023.Day03;

BenchmarkRunner.Run<Benchmarks>();

return;

public class Benchmarks
{
	[GlobalSetup]
	public void Setup()
	{
		DayOneSource();
		DayTwoSource();
	}

	private string[]? _dayOneInput;

	private Day01.PartOneSolution01? _dayOnePartOneSolution01;
	private Day01.PartOneSolution02? _dayOnePartOneSolution02;
	private Day01.PartOneSolution03? _dayOnePartOneSolution03;

	private Day01.PartTwoSolution01? _dayOnePartTwoSolution01;
	private Day01.PartTwoSolution02? _dayOnePartTwoSolution02;
	private Day01.PartTwoSolution03? _dayOnePartTwoSolution03;

	[Benchmark] public long BenchDay01PartOneSolution01() => _dayOnePartOneSolution01!.Solve(_dayOneInput!);
	[Benchmark] public long BenchDay01PartOneSolution02() => _dayOnePartOneSolution02!.Solve(_dayOneInput!);
	[Benchmark] public long BenchDay01PartOneSolution03() => _dayOnePartOneSolution03!.Solve(_dayOneInput!);

	[Benchmark] public long BenchDay01PartTwoSolution01() => _dayOnePartTwoSolution01!.Solve(_dayOneInput!);
	[Benchmark] public long BenchDay01PartTwoSolution02() => _dayOnePartTwoSolution02!.Solve(_dayOneInput!);
	[Benchmark] public long BenchDay01PartTwoSolution03() => _dayOnePartTwoSolution03!.Solve(_dayOneInput!);

	public void DayOneSource()
	{
		_dayOneInput = File.ReadAllLines(@"D:\AoC2023\src\Day01\Input\Input.txt");
		_dayOnePartOneSolution01 = new();
		_dayOnePartOneSolution02 = new();
		_dayOnePartOneSolution03 = new();
		_dayOnePartTwoSolution01 = new();
		_dayOnePartTwoSolution02 = new();
		_dayOnePartTwoSolution03 = new();
	}

	private string[]? _dayTwoInput;

	private Day02.PartOneSolution01? _dayTwoPartOneSolution01;
	private Day02.PartOneSolution02? _dayTwoPartOneSolution02;

	private Day02.PartTwoSolution01? _dayTwoPartTwoSolution01;
	private Day02.PartTwoSolution02? _dayTwoPartTwoSolution02;

	[Benchmark] public long BenchDay02PartOneSolution01() => _dayTwoPartOneSolution01!.Solve(_dayTwoInput!);
	[Benchmark] public long BenchDay02PartOneSolution02() => _dayTwoPartOneSolution02!.Solve(_dayTwoInput!);

	[Benchmark] public long BenchDay02PartTwoSolution01() => _dayTwoPartTwoSolution01!.Solve(_dayTwoInput!);
	[Benchmark] public long BenchDay02PartTwoSolution02() => _dayTwoPartTwoSolution02!.Solve(_dayTwoInput!);

	public void DayTwoSource()
	{
		_dayTwoInput = File.ReadAllLines(@"D:\AoC2023\src\Day02\Input\Input.txt");
		_dayTwoPartOneSolution01 = new();
		_dayTwoPartOneSolution02 = new();
		_dayTwoPartTwoSolution01 = new();
		_dayTwoPartTwoSolution02 = new();
	}

	private string[]? _dayThreeInput;

	private Day03.PartOneSolution01? _dayThreePartOneSolution01;
	private Day03.PartTwoSolution01? _dayThreePartTwoSolution02;

	[Benchmark] private long BenchDay03PartOneSolution01() => _dayThreePartOneSolution01!.Solve(_dayThreeInput!);

	[Benchmark] private long BenchDay03PartTwoSolution02() => _dayThreePartTwoSolution02!.Solve(_dayThreeInput!);

	public void DayThreeSource()
	{
		_dayThreeInput = File.ReadAllLines(@"D:\AoC2023\src\Day02\Input\Input.txt");
		_dayThreePartOneSolution01 = new();
		_dayThreePartTwoSolution02 = new();
	}
}
