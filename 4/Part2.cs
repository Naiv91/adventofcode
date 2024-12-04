using System.Text.RegularExpressions;

namespace _4;

public class Part2(List<string> input)
{
    public void Solve()
    {
        int count = 0;

        List<string> lookUpWords = ["MAS", "SAM"];

        for (var i = 1; i < input.Count - 1; i++)
        {
            int index = 0;
            var letters = input[i].Select(x => x.ToString()).ToList();
            bool first = true;

            while (index != -1)
            {
                index = letters.FindIndex(index + 1, s => s == "A");

                if (first)
                    first = false;

                if (index == -1)
                    break;

                string? ul = null, ur = null, dl = null, dr = null, m = null;
                m = input[i].ElementAt(index).ToString();

                if (index >= 1)
                {
                    ul = input[i - 1].ElementAt(index - 1).ToString();
                    dl = input[i + 1].ElementAt(index - 1).ToString();
                }

                if (letters.Count - 1 - index >= 1)
                {
                    ur = input[i - 1].ElementAt(index + 1).ToString();
                    dr = input[i + 1].ElementAt(index + 1).ToString();
                }

                if (ul != null && ur != null && dl != null && dr != null && m != null)
                    if (lookUpWords.Contains($"{ul}{m}{dr}") && lookUpWords.Contains($"{ur}{m}{dl}"))
                        count++;
            }
        }

        Console.WriteLine(count);
    }
}
