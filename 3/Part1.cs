using System.Text.RegularExpressions;

namespace _3;

public class Part1(string input)
{
    public void Solve()
    {
        Console.WriteLine(Regex.Matches(input, @"mul\((\d{1,3}),(\d{1,3})\)").Sum(m => int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value)));
    }
}
