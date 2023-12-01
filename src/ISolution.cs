using System;

namespace Qtl.AoC2023;

public interface ISolution<TInput>
{
	long Solve(TInput input);
}
