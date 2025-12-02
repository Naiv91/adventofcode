using System.Runtime.CompilerServices;

namespace _1;

public class Part1(List<string> input)
{

    public void Solve()
    {
        int dial = 50;
        int leftAtZero = 0;
        int everyZeroTick = 0;
        foreach (var line in input)
        {
            var dir = line[0];
            var rot = int.Parse(line[1..]);

            for (var i = 0; i < rot; i++)
            {
                if (dir == 'L')
                {
                    if (dial == 0)
                        dial = 99;
                    else
                        dial--;
                }
                else
                {
                    if (dial == 100)
                        dial = 1;
                    else
                        dial++;
                }

                if (dial == 0 || dial == 100)
                {
                    everyZeroTick++;
                }
            }

            if (dial == 0 || dial == 100)
                leftAtZero++;
        }
        Console.WriteLine($"Part1: {leftAtZero}");
        Console.WriteLine($"Part2: {everyZeroTick}");
    }
}
