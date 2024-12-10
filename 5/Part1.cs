using System.Data;
using System.Linq;
using System.Net;

namespace _5;

public class Part1(List<string> input)
{
    public void Solve()
    {
        var rules = input.Where(l => l.Contains('|')).ToList().GroupBy(g => g.Split('|')[0]).Select(group => new { Page = group.Key, Order = group.Select(g => g.Split('|')[1]).ToList() }).ToList();
        var updates =  input.Where(l => l.Contains(',')).ToList().Select(l => l.Split(',').ToList().Select((page, index) => (page, index)).ToList()).ToList();
        int count = 0;

        foreach (var line in updates)
        {
            bool isOk = true;
            for (var i = 0; i < line.Count - 1; i++)
            {
                if (!line.Where(l => l.index > i).Select(l => l.page).ToList().TrueForAll(p => rules.FirstOrDefault(r => r.Page == line[i].page)?.Order.Contains(p) ?? false))
                {
                    isOk = false;
                    break;
                }
            }

            if (isOk)
                count += int.Parse(line[line.Count / 2].page);
        }

        Console.WriteLine(count);
    }
}
