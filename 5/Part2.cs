using System.Text.RegularExpressions;

namespace _5;
public class Part2(List<string> input)
{
    public void Solve()
    {
        var rules = input.Where(l => l.Contains('|')).ToList().GroupBy(g => g.Split('|')[0]).Select(group => new { Page = group.Key, Order = group.Select(g => g.Split('|')[1]).ToList() }).ToList();
        var updates = input.Where(l => l.Contains(',')).ToList().Select(l => l.Split(',').ToList().Select((page, index) => (page, index)).ToList()).ToList();
        int count = 0;

        foreach (var line in updates)
        {
            for (var i = 0; i < line.Count - 1; i++)
            {
                if (!line.Where(l => l.index > i).Select(l => l.page).ToList().TrueForAll(p => rules.FirstOrDefault(r => r.Page == line[i].page)?.Order.Contains(p) ?? false))
                {
                    SortLine(new (line.Select(l => l.page).ToList().Select((page, index) => (page, index))));
                    break;
                }
            } 
        }

        Console.WriteLine(count);

        void SortLine(List<(string page, int index)> fixLine)
        {
            bool isOk = true;
            for (var i = 0; i < fixLine.Count - 1; i++)
            {
                if (!fixLine.Where(l => l.index > i).Select(l => l.page).ToList().TrueForAll(p => rules.FirstOrDefault(r => r.Page == fixLine[i].page)?.Order.Contains(p) ?? false))
                {
                    isOk = false;
                    var temp = fixLine[i];
                    fixLine.Remove(temp);
                    fixLine.Add(temp);
                    SortLine(new (fixLine.Select(l => l.page).ToList().Select((page, index) => (page, index))));
                    break;
                }
            }

            if (isOk)
                count += int.Parse(fixLine[fixLine.Count / 2].page);
        }
    }
}
