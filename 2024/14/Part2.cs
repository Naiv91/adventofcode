public class Part2(List<string> input)
{
    class Robot
    {
        public (int x, int y) P;
        public (int x, int y) V;
    }

    private readonly (int width, int height) Grid = (100, 102);

    public void Solve()
    {
        var robots = input.Select(x => x.Split(' ')).Select(parts => new Robot { P = (x: int.Parse(parts[0].Split('=')[1].Split(',')[0]), y: int.Parse(parts[0].Split('=')[1].Split(',')[1])), V = (x: int.Parse(parts[1].Split('=')[1].Split(',')[0]), y: int.Parse(parts[1].Split('=')[1].Split(',')[1])) }).ToList();

        int ticks = 1;
        while (true)
        {
            robots.ForEach(robot =>
            {
                robot.P = CalcNewPos(robot.P, robot.V);

            });

            var hasConsecutive = robots.GroupBy(robot => robot.P.x).Select(r => r.Select(r => r.P).OrderBy(p => p.y).ToList()).Where(r => r.Count > 10).ToList().Any(group =>
            {
                int consec = 0;

                for (int i = 0; i < group.Count - 1; i++)
                {
                    consec = (group[i].y + 1) == group[i + 1].y ? consec + 1 : 0;

                    if (consec >= 10)
                        return true;
                }

                return false;
            });

            if (hasConsecutive)
            {
                var grid = Enumerable.Range(0, 103).Select(y => Enumerable.Range(0, 101).Select(x => '.').ToList()).ToList();
                robots.ForEach(robot =>
                {
                    grid[robot.P.y][robot.P.x] = 'X';

                });

                Console.WriteLine($"\n{new string('#', 43)} Line {ticks} {new string('#', 43)}\n");
                Console.WriteLine(string.Join(string.Empty, grid.SelectMany(line => string.Join(string.Empty, line) + "\n")) + "\n");

                return;
            }

            ticks++;
        }

        (int x, int y) CalcNewPos((int x, int y) p, (int x, int y) v)
        {
            if (int.IsPositive(v.x))
            {
                if ((p.x + v.x) > Grid.width)
                    p.x = ((p.x + v.x) - Grid.width) - 1;
                else
                {
                    p.x += v.x;
                }

            }
            else
            {
                if ((p.x + v.x) < 0)
                    p.x = (Grid.width - Math.Abs((p.x + v.x))) + 1;
                else
                {
                    p.x += v.x;
                }
            }

            if (int.IsPositive(v.y))
            {
                if ((p.y + v.y) > Grid.height)
                    p.y = ((p.y + v.y) - Grid.height) - 1;
                else
                {
                    p.y += v.y;
                }
            }
            else
            {
                if ((p.y + v.y) < 0)
                    p.y = (Grid.height - Math.Abs((p.y + v.y))) + 1;
                else
                {
                    p.y += v.y;
                }
            }

            return p;
        }

    }
}



