namespace _2;

public partial class Part2(List<string> input)
{
    public void Solve()
    {
        var line1 = input[0].Select(x => x.ToString()).ToList();
        var line2 = input[1].Select(x => x.ToString()).ToList();
        var line3 = input[2].Select(x => x.ToString()).ToList();
        var line4 = input[3].Select(x => x.ToString()).ToList();
        var signs = input[4].Select(x => x.ToString()).ToList();
        long total = 0;

        var sign = string.Empty;
        long sum = 0;
        for (int i = 0; i < line1.Count; i++)
        {
            if (string.IsNullOrEmpty(sign))
                sign = signs[i];

            var c1 = line1[i];
            var c2 = line2[i];
            var c3 = line3[i];
            var c4 = line4[i];


            long combined = string.IsNullOrWhiteSpace($"{c1}{c2}{c3}{c4}") ? 0 : long.Parse($"{c1}{c2}{c3}{c4}");

            if (combined == 0)
            {
                total += sum;
                sum = 0;
                sign = string.Empty;
                continue;
            }

            if (sign == "+")
                sum += combined;
            else
                sum = sum == 0 ? combined : combined * sum;
        }

        total += sum;

        Console.WriteLine(total);
    }
}
