namespace _1;

public class Part1(List<string> input)
{

    public void Solve()
    {
        var left = input.Select(l => int.Parse(l.Split("   ")[0])).ToList().Order().ToList();
        var right = input.Select(l => int.Parse(l.Split("   ")[1])).ToList().Order().ToList();

        var answer = 0;
        var length = left.Count > right.Count ? left.Count : right.Count;

        for (int i = 0; i < length; i++)
        {
            answer += Math.Abs(left[i] - right[i]);
        }

        Console.WriteLine($"{answer}");
    }
}
