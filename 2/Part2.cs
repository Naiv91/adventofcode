namespace _2;

public class Part2(List<string> input)
{
    public void Solve()
    {
        int answer = 0;

        foreach (var line in input)
        {
            var parts = line.Split(' ').Select(int.Parse).ToList();


            for (int h = 0; h <= parts.Count; h++)
            {
                bool safe = true;
                bool allIncrease = false;
                var skipList = parts.ToList();

                if (h > 0)
                    skipList.RemoveAt(h - 1);

                for (int i = 0; i < skipList.Count - 1; i++)
                {
                    if (PartHelper.LevelHasError(ref allIncrease, skipList[i], skipList[i + 1], i))
                    {
                        safe = false;
                        break;
                    }
                }

                if (safe)
                {
                    answer++;
                    break;
                }

            }
        }

        Console.WriteLine($"{answer}");
    }
}
