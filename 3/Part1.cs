using System.Text.RegularExpressions;

namespace _2;

public class Part1(string input)
{
    public void Solve()
    {
        var muls = new Regex(@"mul\(\d{1,3},\d{1,3}\)");
        var digits = new Regex(@"\d{1,}");
        var matches = muls.Matches(input);
        var sum = matches.Sum(m => int.Parse(digits.Match(m.Value.Split(',').First()).Value) * int.Parse(digits.Match(m.Value.Split(',').Last()).Value));

        Console.WriteLine(sum);
    }
}
