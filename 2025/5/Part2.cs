namespace _2;

public partial class Part2(List<string> input)
{
    public void Solve()
    {
        var ranges = input
            .TakeWhile(line => string.IsNullOrWhiteSpace(line) || line.Contains('-'))
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => line.Split('-').Select(x => long.Parse(x)).ToArray())
            .OrderBy(a => a[0])
            .ToList();

        var merged = new List<long[]>();
        foreach (var r in ranges)
        {
            if (merged.Count == 0)
            {
                merged.Add(new[] { r[0], r[1] });
                continue;
            }

            var last = merged[^1];
            if (r[0] <= last[1])
            {
                last[1] = Math.Max(last[1], r[1]);
            }
            else
            {
                merged.Add([r[0], r[1]]);
            }
        }


        // exoected answer 352946349407338
        Console.WriteLine(merged.Sum(r => r[1] - r[0] + 1));
    }
}
