public class Part1(List<string> input)
{
    public void Solve()
    {
        var robots = input.Select(x => x.Split(' ')).Select(parts => (p: (x: int.Parse(parts[0].Split('=')[1].Split(',')[0]), y: int.Parse(parts[0].Split('=')[1].Split(',')[1])), v: (x: int.Parse(parts[1].Split('=')[1].Split(',')[0]), y: int.Parse(parts[1].Split('=')[1].Split(',')[1])))).ToList();
        int maxX = 100;
        int maxY = 102;
        int mX = (maxX + 1) / 2;
        int mY = (maxY + 1) / 2;

        var finalPos = robots.Select(x => FinalPosition(x.p, x.v, 100, [])).ToList();
        var finalBots = finalPos.Where(r => r.x != mX && r.y != mY).ToList();

        var quads = (0, 0, 0, 0);

        foreach (var robot in finalBots)
        {
            if (robot.x < mX && robot.y < mY)
                quads.Item1++;
            else if (robot.x > mX && robot.y < mY)
                quads.Item2++;
            else if (robot.x < mX && robot.y > mY)
                quads.Item3++;
            else
                quads.Item4++;

        }

        Console.WriteLine(quads.Item1 * quads.Item2 * quads.Item3 * quads.Item4);

        (int x, int y) FinalPosition((int x, int y) p, (int x, int y) v, int tick, List<(int x, int y)> visited)
        {
            if (tick < 0)
                return visited.Last();

            visited.Add(p);
            var next = CalcNewPos(p, v);
            return FinalPosition(next, v, tick - 1, visited);
        }

        (int x, int y) CalcNewPos((int x, int y) p, (int x, int y) v)
        {
            if (int.IsPositive(v.x))
            {
                if ((p.x + v.x) > maxX)
                    p.x = ((p.x + v.x) - maxX) - 1;
                else
                {
                    p.x += v.x;
                }

            }
            else
            {
                if ((p.x + v.x) < 0)
                    p.x = (maxX - Math.Abs((p.x + v.x))) + 1;
                else
                {
                    p.x += v.x;
                }
            }

            if (int.IsPositive(v.y))
            {
                if ((p.y + v.y) > maxY)
                    p.y = ((p.y + v.y) - maxY) - 1;
                else
                {
                    p.y += v.y;
                }
            }
            else
            {
                if ((p.y + v.y) < 0)
                    p.y = (maxY - Math.Abs((p.y + v.y))) + 1;
                else
                {
                    p.y += v.y;
                }
            }
            return p;
        }
    }
}
