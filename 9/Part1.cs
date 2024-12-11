using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;

public class Part1(List<string> input)
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

        long sum = 0;

        for (var i = 0; i < blocks.Count; i++)
        {
            if (blocks[i].b == ".")
            {
                var last = blocks.Last(x => x.b != ".");
                blocks.RemoveAt(last.i);
                sum += (long.Parse(last.b.ToString()) * i);
            }
            else
            {
                sum += (long.Parse(blocks[i].b) * i);
            }

            if (blocks.Last().b == ".")
                blocks.Remove(blocks.Last());
        }

        Console.WriteLine(sum);
    }
}
