using System.Data;

public class Part1(List<string> input)
{
    public void Solve()
    {
        long result = 0;
        foreach (var line in input)
        {
            var answer = long.Parse(line.Split(':')[0]);
            var numbers = line.Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => int.Parse(x)).ToList();
            List<List<string>> combos = [];
            GetCombos("", numbers.Count - 1, combos);
            

            foreach (var combo in combos)
            {
                long check = 0;
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (i == 0)
                    {
                        check += numbers[i];
                        continue;
                    }

                    if (combo[i - 1] == "+")
                        check += numbers[i];

                    if (combo[i - 1] == "*")
                        check *= numbers[i];
                }

                if (check == answer)
                {
                    result += answer;
                    break;
                }
            }
            

            
        }

        Console.WriteLine(result);

        static void GetCombos(string current, int operators, List<List<string>> combos)
        {
            if (operators == 0)
            {
                combos.AddRange(current.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());
                return;
            }

            GetCombos(current +  ";+", operators - 1, combos);
            GetCombos(current + ";*", operators - 1, combos);
        }
    }
}
