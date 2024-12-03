using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2;

public class Part1(List<string> input)
{
    public void Solve()
    {
        int answer = 0;

        foreach (var line in input)
        {
            var parts = line.Split(' ').Select(int.Parse).ToList();
            bool safe = true;
            bool allIncrease = false;

            for (int i = 0; i < parts.Count - 1; i++)
            {
                if (PartHelper.LevelHasError(ref allIncrease, parts[i], parts[i + 1], i))
                {
                    safe = false;
                    break;
                }

            }

            if (safe)
                answer++;
        }

        Console.WriteLine($"{answer}");
    }
}
