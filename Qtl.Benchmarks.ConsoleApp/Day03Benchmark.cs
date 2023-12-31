﻿using BenchmarkDotNet.Attributes;
using Qtl.AoC2023.Day03;

namespace Qtl.Benchmarks.ConsoleApp;

public class Day03Benchmark
{
	[GlobalSetup]
	public void Setup()
	{
		_input = File.ReadAllLines(@"D:\AoC2023\src\Day03\Input\Input.txt");
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

	[Benchmark] public long BenchDay03PartOneSolution01() => _partOneSolution01!.Solve(_input!);
	[Benchmark] public long BenchDay03PartOneSolution02() => _partOneSolution02!.Solve(_input!);

	[Benchmark] public long BenchDay03PartTwoSolution01() => _partTwoSolution01!.Solve(_input!);
	[Benchmark] public long BenchDay03PartTwoSolution02() => _partTwoSolution02!.Solve(_input!);
}
