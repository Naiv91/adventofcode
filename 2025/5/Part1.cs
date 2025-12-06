using System.Diagnostics;
using System.Runtime.InteropServices;

namespace _1;

public partial class Part1(List<string> input)
{
    public void Solve()
    {
        var ranges = input.TakeWhile(line => !string.IsNullOrWhiteSpace(line)).Select(line => line.Split('-').Select(x => long.Parse(x)).ToList()).ToList();
        var ids = input.Skip(ranges.Count + 1).Select(i => long.Parse(i)).ToList();
        int fresh = 0;

        foreach (var id in ids)
        {
            foreach (var range in ranges)
            {
                if (id >= range[0] && id <= range[1])
                {
                    fresh++;
                    break;
                }
            }
        }

        Console.WriteLine(fresh);
    }
}
