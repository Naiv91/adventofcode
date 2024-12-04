using System.Text.RegularExpressions;

namespace _3;

public class Part1(string input)
{
    public void Solve()
    {
        Console.WriteLine(Regex.Matches(input, @"mul\(\d{1,3},\d{1,3}\)").Sum(m => int.Parse(Regex.Match(m.Value.Split(',').First(), @"\d{1,}").Value) * int.Parse(Regex.Match(m.Value.Split(',').Last(), @"\d{1,}").Value)));
    }
}
