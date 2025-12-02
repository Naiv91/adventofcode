using System.Text.RegularExpressions;
public class Part2(List<string> input)
{
    public void Solve()
    {
        var stones = input.First().Split(' ').Select(c => long.Parse(c)).ToList();

        Dictionary<(long stone, int blink), long> knowns = [];

        Console.WriteLine(stones.Sum(s => CheckStone(s, 75)));

        long CheckStone(long stone, int blink)
        {
            if (knowns.TryGetValue((stone, blink), out long res))
                return res;

            var strStone = stone.ToString();

            if (blink == 0)
                res = 1;
            else if (stone == 0)
                res = CheckStone(1, blink - 1);
            else if (strStone.Length % 2 == 0)
                res = CheckStone(long.Parse(strStone[..(strStone.Length / 2)]), blink - 1) + CheckStone(long.Parse(strStone[(strStone.Length / 2)..]), blink - 1);
            else
                res = CheckStone(stone * 2024, blink - 1);

            knowns.Add((stone, blink), res);
            return res;
        }
    }
}
