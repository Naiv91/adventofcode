namespace _2;

public class Part2(List<string> input)
{
    public void Solve()
    {
        var left = input.Select(l => int.Parse(l.Split("   ")[0])).ToList().GroupBy(n => n).Select(group => new { Number = group.Key, Count = group.Count() }).ToList();
        var right = input.Select(l => int.Parse(l.Split("   ")[1])).ToList().GroupBy(n => n).Select(group => new { Number = group.Key, Count = group.Count() }).ToList();

        var answer = 0;

        foreach (var item in left)
        {
            var rightCount = right.FirstOrDefault(r => r.Number == item.Number)?.Count ?? 0;
            answer += item.Number * item.Count * rightCount;
        }

        Console.WriteLine($"{answer}");
    }


}