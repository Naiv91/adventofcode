using System.Data;

public class Part1(List<string> input)
{
    public void Solve()
    {
        Dictionary<char, List<(int x, int y)>> valuePairs = [];
        var grid = input.Select(y => y.Select(x => x).ToList()).ToList();

        Enumerable.Range(0, grid.Count).SelectMany(y => Enumerable.Range(0, grid[0].Count).Select(x => (x, y))).ToList().ForEach(cord => {
            var plant = grid[cord.y][cord.x];
            if (valuePairs.TryGetValue(plant, out var cords))
                cords.Add((cord.x, cord.y));
            else
                valuePairs[plant] = [(cord.x, cord.y)];
        });

        long price = 0;

        foreach ( var pair in valuePairs )
        {
            Dictionary<string, List<(int x, int y)>> regions = [];
            int counter = 1;
            bool first = true;

            string key = "";

            foreach (var cord in pair.Value)
            {
                if (first)
                {
                    first = false;
                    key = $"{pair.Key}{counter}";
                    regions[key] = [cord];
                }

                if (!regions[key].Any(c => c == cord))
                {


                    counter++;
                    key = $"{pair.Key}{counter}";
                    regions[key] = [cord];
                }

                if (cord.x + 1 < grid[cord.y].Count)
                {
                    if (grid[cord.y][cord.x + 1] == pair.Key)
                    {
                        if (!regions[key].Any(c => c.x == cord.x + 1 && c.y == cord.y))
                            regions[key].Add((cord.x + 1, cord.y));
                    }
                }
                
                if (cord.y + 1 < grid.Count)
                {
                    if (grid[cord.y + 1][cord.x] == pair.Key)
                    {
                        if (!regions[key].Any(c => c.x == cord.x && c.y == cord.y + 1))
                            regions[key].Add((cord.x, cord.y + 1));
                    }
                }
            }

            foreach (var region in regions)
            {
                int area = region.Value.Count;
                int perimiter = region.Value.Sum(cord => Perimiters(cord, region.Key[0]));

                price += area * perimiter;
            }
        }

        (int x, int y) CheckNeighbours((int x, int y) cord, char plant)
        {
            if (cord.x - 1 >= 0 && cord.x + 1 < grid[cord.y].Count)
            {
                if (grid[cord.y][cord.x + 1] != plant)
                    CheckNeighbours((cord.x + 1, cord.y), plant);

                if (grid[cord.y][cord.x - 1] != plant)
                    CheckNeighbours((cord.x - 1, cord.y), plant);
            }

            if (cord.x - 1 >= 0 && cord.x + 1 < grid[cord.y].Count)
            {
                if (grid[cord.y + 1][cord.x] != plant)
                    CheckNeighbours((cord.x, cord.y + 1), plant);

                if (grid[cord.y - 1][cord.x] != plant)
                    CheckNeighbours((cord.x, cord.y + 1), plant);
            }

            return cord;
        }

        Console.WriteLine(price);

        int Perimiters((int x, int y) cord, char plant)
        {
            int count = 0;

            if (cord.x + 1 == grid[0].Count || cord.x - 1 < 0)
            {
                count++;
            }
            else
            {
                {
                    if (grid[cord.y][cord.x + 1] != plant)
                        count++;

                    if (grid[cord.y][cord.x - 1] != plant)
                        count++;
                }
            }

            if (cord.y + 1 == grid[0].Count || cord.y - 1 < 0)
            {
                count++;
            }
            else
            {

                if (grid[cord.y + 1][cord.x] != plant)
                    count++;

                if (grid[cord.y - 1][cord.x] != plant)
                    count++;
            }

            return count;
        }
    }
}
