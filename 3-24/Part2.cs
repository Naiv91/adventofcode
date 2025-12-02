using System.Text.RegularExpressions;

namespace _3;

public class Part2(string input)
{
    public void Solve()
    {
        string mulEnabled = string.Join(string.Empty, input.Split("do()").Select(l => l.Split("don't").First()));

        Console.WriteLine(Regex.Matches(mulEnabled, @"mul\((\d{1,3}),(\d{1,3})\)").Sum(m => int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value)));
    }
}