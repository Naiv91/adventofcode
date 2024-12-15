using System.Linq;
using System.Xml.XPath;

public class Part1(List<string> input)
{
    public void Solve()
    {
        var grid = input.Select(y => y.Select(x => int.Parse(x.ToString())).ToList()).ToList();

       Console.WriteLine(Enumerable.Range(0, input.Count).SelectMany(y => Enumerable.Range(0, input[0].Length).Select(x => (x, y))).Where(cord => grid[cord.y][cord.x] == 0).Sum(cord => FindTrailHeads((cord.x, cord.y), [], 0).Count));

        List<(int x, int y)> FindTrailHeads((int x, int y) pos, List<(int x, int y)> paths, int shouldBe)
        {
            if (!
                (
                    (pos.x < grid[0].Count) &&
                    (pos.x >= 0) && 
                    (pos.y >= 0) &&
                    (pos.y < grid.Count)
                ) ||
                grid[pos.y][pos.x] != shouldBe)
            {
                return paths;
            }

            if (shouldBe == 9)
            {
                paths.Add(pos);
                return paths;
            }

            shouldBe += 1;
            return
                FindTrailHeads((pos.x + 1, pos.y), paths, shouldBe).Union
                (FindTrailHeads((pos.x - 1, pos.y), paths, shouldBe).Union
                (FindTrailHeads((pos.x, pos.y + 1), paths, shouldBe).Union
                (FindTrailHeads((pos.x, pos.y - 1), paths, shouldBe)))).ToList();
        }
    }
}
