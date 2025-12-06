using System.Data;

public class Part1(List<string> input)
{
    public void Solve()
    {
        Dictionary<char, List<(int x, int y)>> valuePairs = [];
        var grid = input.Select(y => y.Select(x => x).ToList()).ToList();

        Enumerable.Range(0, grid.Count).SelectMany(y => Enumerable.Range(0, grid[0].Count).Select(x => (x, y))).ToList().ForEach(cord =>
        {
            var plant = grid[cord.y][cord.x];
            if (valuePairs.TryGetValue(plant, out var cords))
                cords.Add((cord.x, cord.y));
            else
                valuePairs[plant] = [(cord.x, cord.y)];
        });

        long price = 0;

        foreach (var pair in valuePairs)
        {
            while (true)
            {
                if (pair.Value.Count == 0) break;

                var cord = pair.Value.FirstOrDefault();

                List<(int x, int y)> connected = CheckNeighbours(cord, pair.Key, []);
                int area = connected.Count;
                int perimiter = connected.Sum(cord => Perimiters(cord, pair.Key));
                price += area * perimiter;

                // Console.WriteLine($"{pair.Key}: {area} * {perimiter} = {area * perimiter}");

                connected.ForEach(item => pair.Value.Remove(item));

                cord = pair.Value.FirstOrDefault();
            }
        }

        List<(int x, int y)> CheckNeighbours((int x, int y) cord, char plant, List<(int x, int y)> visited)
        {
            if (cord.x + 1 < grid[cord.y].Count)
                if (!visited.Any(v => v == (cord.x + 1, cord.y)))
                    if (grid[cord.y][cord.x + 1] == plant)
                    {
                        visited.Add(cord);
                        visited = visited.Union(CheckNeighbours((cord.x + 1, cord.y), plant, visited)).ToList();
                    }

            if (cord.x - 1 >= 0)
                if (!visited.Any(v => v == (cord.x - 1, cord.y)))
                    if (grid[cord.y][cord.x - 1] == plant)
                    {
                        visited.Add(cord);
                        visited = visited.Union(CheckNeighbours((cord.x - 1, cord.y), plant, visited)).ToList();
                    }

            if (cord.y + 1 < grid.Count)
                if (!visited.Any(v => v == (cord.x, cord.y + 1)))
                    if (grid[cord.y + 1][cord.x] == plant)
                    {
                        visited.Add(cord);
                        visited = visited.Union(CheckNeighbours((cord.x, cord.y + 1), plant, visited)).ToList();
                    }

            if (cord.y - 1 >= 0)
                if (!visited.Any(v => v == (cord.x, cord.y - 1)))
                    if (grid[cord.y - 1][cord.x] == plant)
                    {
                        visited.Add(cord);
                        visited = visited.Union(CheckNeighbours((cord.x, cord.y - 1), plant, visited)).ToList();
                    }

            if (!visited.Any(v => v == cord))
                visited.Add(cord);

            return visited;
        }

        Console.WriteLine(price);

        int Perimiters((int x, int y) cord, char plant)
        {
            int count = 0;

            if (cord.x + 1 == grid[0].Count)
            {
                count++;
            }
            else
            {
                if (grid[cord.y][cord.x + 1] != plant)
                    count++;
            }

            if (cord.x - 1 < 0)
            {
                count++;
            }
            else
            {
                if (grid[cord.y][cord.x - 1] != plant)
                    count++;
            }
            


            if (cord.y + 1 == grid[0].Count)
            {
                count++;
            }
            else
            {

                if (grid[cord.y + 1][cord.x] != plant)
                    count++;
            }

            if (cord.y - 1 < 0)
            {
                count++;
            }
            else
            {
                if (grid[cord.y - 1][cord.x] != plant)
                    count++;
            }

            return count;
        }
    }
}
