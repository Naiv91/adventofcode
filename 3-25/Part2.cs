using System;
using System.Diagnostics;
using System.Threading;

namespace _3_25;

public class Part2(List<string> input, CancellationToken cancellationToken)
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

            long joltage = NestedLoop(0, string.Empty, 0);
            Interlocked.Add(ref joltSum, joltage);

            long NestedLoop(int start, string number, int max)
            {
                int index = -1;

                // At the end of the line, just return
                if (start - 1 == (line.Length - (12 - number.Length)))
                {
                    max = int.Parse(line.ElementAt(start + 1).ToString());
                    index = start + 1;
                }
                else
                {
                    for (var j = start; j < line.Length; j++)
                    {
                        if ((int.TryParse(line[j].ToString(), out int num) && num > max))
                        {
                            max = num;
                            index = j;
                        }

                        if ((line.Length - j) == (12 - number.Length))
                            break;
                    }
                }

                if (number.Length < 12)
                    number = $"{number}{max}";

                if (number.Length < 12)
                    return NestedLoop(index + 1, number, 0);

                return long.Parse(number);
            }
        });

        stopwatch.Stop();
        Console.WriteLine($"{joltSum}");
        Console.WriteLine($"Parallell elapsed time: {stopwatch.Elapsed}");
    }
}