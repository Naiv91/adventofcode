namespace _2;

public partial class Part2(List<string> input)
{
    public void Solve()
    {
        var ranges = input.TakeWhile(line => !string.IsNullOrWhiteSpace(line)).Select(line => line.Split('-').Select(x => long.Parse(x)).ToList()).OrderBy(r => r[0]).ToList();
        var starts = new List<long>();
        var ends = new List<long>();

        CleanRanges();
        void CleanRanges()
        {
            foreach (var test in ranges.OrderBy(r => r[0]))
            {
                var toCheck = ranges.Where(r => r != test && test[1] >= r[0] && test[1] <= r[1]).OrderBy(r => r[1]).ToList();

                if (toCheck.Count > 0)
                {
                    ranges.Add([test[0], toCheck.Last()[1]]);
                    ranges.Remove(test);
                    toCheck.ForEach(r => ranges.Remove(r));
                    CleanRanges();
                    break;
                }

            }

            return;
        }

        Console.WriteLine(ranges.Sum(r => r[1] - r[0] + 1));
    }
}
