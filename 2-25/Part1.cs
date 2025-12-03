using System.Collections.Concurrent;

namespace _2_25;

public partial class Part1(List<string> input, CancellationToken cancellationToken)
{
    private static long s_invalidSum;

    public async Task Solve()
    {
        var ids = input.SelectMany(s => s.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
        Interlocked.Exchange(ref s_invalidSum, 0L);
        
        ParallelOptions parallelOptions = new()
        {
            CancellationToken = cancellationToken,
            MaxDegreeOfParallelism = Environment.ProcessorCount
        };

        await Parallel.ForEachAsync(ids, parallelOptions, async (line, token) =>
        {
            token.ThrowIfCancellationRequested();
            var regex = DigitOcurrences();
            var start = long.Parse(line.Split('-')[0]);
            var end = long.Parse(line.Split('-')[1]);
            
            for (long i = start; i <= end; i++)
            {
                token.ThrowIfCancellationRequested();

                var matches = regex.Matches(i.ToString());

                if (matches.Count > 0)
                {
                    Interlocked.Add(ref s_invalidSum, (long)i);
                }
            }
        });

        Console.WriteLine($"Invalid passwords count: {s_invalidSum}");
    }

    // Part1: [System.Text.RegularExpressions.GeneratedRegex(@"^(\d+)\1$")]
    [System.Text.RegularExpressions.GeneratedRegex(@"^(\d+?)\1+$")]
    private static partial System.Text.RegularExpressions.Regex DigitOcurrences();
}
