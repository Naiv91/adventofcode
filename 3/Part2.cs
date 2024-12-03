using System.Text.RegularExpressions;

namespace _2;

public class Part2(string input)
{
    public void Solve()
    {
        string mulEnabled = string.Join(string.Empty, input.Split("do()").Select(l => l.Split("don't").First()));

        Console.WriteLine(Regex.Matches(mulEnabled, @"mul\(\d{1,3},\d{1,3}\)").Sum(m => int.Parse(Regex.Match(m.Value.Split(',').First(), @"\d{1,}").Value) * int.Parse(Regex.Match(m.Value.Split(',').Last(), @"\d{1,}").Value)));
    }
}
