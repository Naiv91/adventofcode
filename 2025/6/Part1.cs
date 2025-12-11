namespace _1;

public partial class Part1(List<string> input)
{
    public void Solve()
    {
        var grid = input.SkipLast(1).Select(y => y.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(x => long.Parse(x)).ToList()).ToList();
        var signs = input.ToList().Select(y => y.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)).Last().Select(x => x).ToList();
        long total = 0;

        for (int x = 0; x < grid.First().Count; x++)
        {
            long rowTotal = 1;
            var sign = signs[x];
            for (int y = 0; y < grid.Count; y++)
            {
                if (sign == "+")
                    rowTotal += grid[y][x];
                else
                    rowTotal *= grid[y][x];
            }

            total += sign == "*" ? rowTotal : rowTotal - 1;
        }

        Console.WriteLine(total);
    }
}
