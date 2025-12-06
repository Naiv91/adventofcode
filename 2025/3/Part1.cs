using System.Diagnostics;

namespace _1;

public partial class Part1(List<string> input, CancellationToken cancellationToken)
{
    private static long joltSum;

    public async Task Solve()
    {
        var stopwatch = Stopwatch.StartNew();
        Interlocked.Exchange(ref joltSum, 0L);

        ParallelOptions parallelOptions = new()
        {
            CancellationToken = cancellationToken,
            MaxDegreeOfParallelism = Environment.ProcessorCount
        };

        await Parallel.ForEachAsync(input, parallelOptions, async (line, token) =>
         {
             token.ThrowIfCancellationRequested();

             int joltage = 0;

            for (var i = 0; i < line.Length; i++)
            {
                for (var j = (i + 1); j < line.Length; j++)
                {
                    var test = int.Parse($"{line[i]}{line[j]}");
                    
                    if (test > joltage)
                    {
                        joltage = test;
                    }
                }
            }
            Interlocked.Add(ref joltSum, joltage);
         });

        stopwatch.Stop();
        Console.WriteLine($"{joltSum}");
        Console.WriteLine($"Parallell elapsed time: {stopwatch.Elapsed}");
    }
}
