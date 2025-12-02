using System.Text.RegularExpressions;
public class Part2(List<string> input)
{
    public void Solve()
    {
        var blocks = input.First().Select(x => int.Parse(x.ToString())).Select((number, index) =>
        {
            List<string> row = [];
            for (int i = 0; i < number; i++)
            {
                if (index % 2 == 0)
                    row.Add((index - (index / 2)).ToString());
                else
                    row.Add(".");
            }
            return row;
        }).SelectMany(row => row).Select((b, i) => (b, i)).ToList();

        var groups = blocks.Where(block => block.b != ".").GroupBy(block => block.b).Select(group => new { Key = group.Key, Indexes = group.Select(g => g.i).ToList(), Count = group.Count() }).ToList();

        long sum = 0;

        while (true)
        {
            var lastGroup = groups.LastOrDefault();

            if (lastGroup is null)
                break;

            var leftMostFreeSpace = blocks.FirstOrDefault(block => block.b == "." && block.i < lastGroup.Indexes.Min() && ConsecutiveDots(block.i, lastGroup.Count));

            if (leftMostFreeSpace.b == ".")
                CheckSum(lastGroup.Key, Enumerable.Range(leftMostFreeSpace.i, lastGroup.Count).ToList());
            else
                CheckSum(lastGroup.Key, lastGroup.Indexes);

            groups.Remove(lastGroup);
        }

        void CheckSum(string key, List<int> indexes)
        {
            indexes.ForEach(i => { sum += long.Parse(key) * i; blocks[i] = (key, i); });
        }

        bool ConsecutiveDots(int start, int count)
        {
            int stop = start + count;
            while (start < stop)
            {
                if (blocks[start].b != ".")
                    return false;

                start++;
            }

            return true;
        }

        Console.WriteLine(sum);

    }
}
