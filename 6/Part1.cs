using System.Data;
using System.Linq;
using System.Net;

public class Part1(List<string> input)
{
    public void Solve()
    {
        List<char> directions = ['^', '>', 'v', '<'];
        var grid = input.Select(y => y.Select(x => x).ToList()).ToList();
        var cords = Enumerable.Range(0, grid.Count).SelectMany(y => Enumerable.Range(0, grid[0].Count).Select(x => (x, y)));
        var guardPos = cords.First(pos => directions.Contains(grid[pos.y][pos.x]));
        var nextPos = guardPos;
        var direction = grid[guardPos.y][guardPos.x];

        List<(int x, int y)> visited = [];

        while (true)
        {
            Step();

            if (nextPos.x < 0 || nextPos.x == grid[0].Count || nextPos.y < 0 || nextPos.y == grid.Count)
            {
                visited.Add(guardPos);
                break;
            }
                
            if (grid[nextPos.y][nextPos.x] == '#')
            {
                direction = directions[directions.IndexOf(direction) + 1 == directions.Count ? 0 : directions.IndexOf(direction) + 1];
                nextPos = guardPos;
            }
            else
            {
                visited.Add(guardPos);
                guardPos = nextPos;
            }
            
        }

        Console.WriteLine(visited.Distinct().Count());

        void Step()
        {
            switch (direction)
            {
                case '^':
                    nextPos.y--;
                    break;
                case '>':
                    nextPos.x++;
                    break;
                case 'v':
                    nextPos.y++;
                    break;
                default:
                    nextPos.x--;
                    break;
            }
        }
    }
}
