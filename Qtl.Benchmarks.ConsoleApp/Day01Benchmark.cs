using BenchmarkDotNet.Attributes;
using Qtl.AoC2023.Day01;

namespace Qtl.Benchmarks.ConsoleApp;

public class Day01Benchmark
{
	[GlobalSetup]
	public void Setup()
	{
		_input = File.ReadAllLines(@"D:\AoC2023\src\Day01\Input\Input.txt");
		_partOneSolution01 = new();
		_partOneSolution02 = new();
		_partOneSolution03 = new();
		_partTwoSolution01 = new();
		_partTwoSolution02 = new();
	}

	private string[]? _input;

	private PartOneSolution01? _partOneSolution01;
	private PartOneSolution02? _partOneSolution02;
	private PartOneSolution03? _partOneSolution03;

	private PartTwoSolution01? _partTwoSolution01;
	private PartTwoSolution02? _partTwoSolution02;
	private PartTwoSolution03? _partTwoSolution03;
	
	[Benchmark] public long BenchDay01PartOneSolution01() => _partOneSolution01!.Solve(_input!);
	[Benchmark] public long BenchDay01PartOneSolution02() => _partOneSolution02!.Solve(_input!);
	[Benchmark] public long BenchDay01PartOneSolution03() => _partOneSolution03!.Solve(_input!);

	[Benchmark] public long BenchDay01PartTwoSolution01() => _partTwoSolution01!.Solve(_input!);
	[Benchmark] public long BenchDay01PartTwoSolution02() => _partTwoSolution02!.Solve(_input!);
	[Benchmark] public long BenchDay01PartTwoSolution03() => _partTwoSolution03!.Solve(_input!);
}
