
## Results:

```
BenchmarkDotNet v0.13.10, Windows 11 (10.0.22631.2715/23H2/2023Update/SunValley3)
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2
```

| Method                      | Mean        | Error     | StdDev    |
|---------------------------- |------------:|----------:|----------:|
| Day 1 part 1                |             |           |           |
| BenchDay01PartOneSolution01 |    48.89 us |  0.228 us |  0.190 us |
| BenchDay01PartOneSolution02 |    55.19 us |  0.607 us |  0.538 us |
| BenchDay01PartOneSolution03 | 1,447.59 us | 17.610 us | 16.472 us |
| Day 1 part 2                |             |           |           |
| BenchDay01PartTwoSolution01 | 1,140.91 us |  4.656 us |  4.355 us |
| BenchDay01PartTwoSolution02 | 1,243.68 us | 14.470 us | 12.827 us |
| BenchDay01PartTwoSolution03 | 2,294.91 us | 41.695 us | 39.001 us |
| Day 2 part 1                |             |           |           |
| BenchDay02PartOneSolution01 |    79.98 us |  1.367 us |  2.088 us |
| BenchDay02PartOneSolution02 |    30.31 us |  0.382 us |  0.338 us |
| Day 2 part 2                |             |           |           |
| BenchDay02PartTwoSolution01 |   296.99 us |  5.035 us |  4.710 us |
| BenchDay02PartTwoSolution02 |   204.82 us |  4.054 us |  4.978 us |
| ...                         |             |           |           |
