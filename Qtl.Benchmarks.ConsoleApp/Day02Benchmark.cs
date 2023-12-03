using BenchmarkDotNet.Attributes;
using Qtl.AoC2023.Day02;

namespace Qtl.Benchmarks.ConsoleApp;

public class Day02Benchmark
{
	[GlobalSetup]
	public void Setup()
	{
		_input = File.ReadAllLines(@"D:\AoC2023\src\Day02\Input\Input.txt");
		_partOneSolution01 = new();
		_partOneSolution02 = new();
		_partTwoSolution01 = new();
		_partTwoSolution02 = new();
	}

	private string[]? _input;

	private PartOneSolution01? _partOneSolution01;
	private PartOneSolution02? _partOneSolution02;

	private PartTwoSolution01? _partTwoSolution01;
	private PartTwoSolution02? _partTwoSolution02;

	[Benchmark] public long BenchDay02PartOneSolution01() => _partOneSolution01!.Solve(_input!);
	[Benchmark] public long BenchDay02PartOneSolution02() => _partOneSolution02!.Solve(_input!);

	[Benchmark] public long BenchDay02PartTwoSolution01() => _partTwoSolution01!.Solve(_input!);
	[Benchmark] public long BenchDay02PartTwoSolution02() => _partTwoSolution02!.Solve(_input!);
}
