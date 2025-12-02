using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;

public class Part1(List<string> input)
{
    public void Solve()
    {
        var stones = input.First().Split(' ').Select(c => long.Parse(c)).ToList();

        for (int i = 0; i < 25; i++)
        {
            List<long> temp = [];

            for (int j = 0; j < stones.Count; j++)
            {
                var stone = stones[j];
                var strStone = stone.ToString();

                if (stone == 0)
                    temp.Add(1);
                else if (strStone.Length % 2 == 0)
                {
                    temp.Add(long.Parse(strStone.Substring(0, (strStone.Length / 2))));
                    temp.Add(long.Parse(strStone.Substring(((strStone.Length / 2)), (strStone.Length / 2))));
                }
                else
                {
                    temp.Add(stone * 2024);
                }
            }

            stones = [.. temp];
        }

        Console.WriteLine(stones.Count);
    }
}
