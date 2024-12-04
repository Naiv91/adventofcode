using System;
using System.Text.RegularExpressions;

namespace _4;

public class Part1(List<string> input)
{
    public void Solve()
    {
        int count = 0;

        var lookupWord = "XMAS";

        for (var i = 0; i < input.Count; i++)
        {
            int index = 0;
            var letters = input[i].Select(x => x.ToString()).ToList();
            bool first = true;

            while (index != -1)
            {
                index = letters.FindIndex(first ? 0 : index + 1, s => s == lookupWord.First().ToString());

                if (first)
                    first = false;

                if (index == -1)
                    break;

                // right
                CheckRight(letters, index);

                // left
                CheckLeft(letters, index);

                // up
                CheckUp(i, index);

                // down
                CheckDown(i, index);
            }
        }

        Console.WriteLine(count);

        void CheckRight(List<string> letters, int index)
        {
            if ((letters.Count - 1 - index) >= 3)
                if ($"{letters[index]}{letters[index + 1]}{letters[index + 2]}{letters[index + 3]}" == lookupWord)
                    count++;
        }

        void CheckLeft(List<string> letters, int index)
        {
            if (index >= 3)
                if ($"{letters[index]}{letters[index - 1]}{letters[index - 2]}{letters[index - 3]}" == lookupWord)
                    count++;
        }

        void CheckUp(int i, int index)
        {
            if (i >= 3)
                if ($"{input[i].ElementAt(index)}{input[i - 1].ElementAt(index)}{input[i - 2].ElementAt(index)}{input[i - 3].ElementAt(index)}" == lookupWord)
                    count++;

            if (i >= 3 && (input[i].ToList().Count - 1 - index) >= 3)
                if ($"{input[i].ElementAt(index)}{input[i - 1].ElementAt(index + 1)}{input[i - 2].ElementAt(index + 2)}{input[i - 3].ElementAt(index + 3)}" == lookupWord)
                    count++;

            if (i >= 3 && index >= 3)
                if ($"{input[i].ElementAt(index)}{input[i - 1].ElementAt(index - 1)}{input[i - 2].ElementAt(index - 2)}{input[i - 3].ElementAt(index - 3)}" == lookupWord)
                    count++;
        }

        void CheckDown(int i, int index)
        {
            if ((input.Count - 1 - i) >= 3)
                if ($"{input[i].ElementAt(index)}{input[i + 1].ElementAt(index)}{input[i + 2].ElementAt(index)}{input[i + 3].ElementAt(index)}" == lookupWord)
                    count++;

            if ((input.Count - 1 - i) >= 3 && (input[i].ToList().Count - 1 - index) >= 3)
                if ($"{input[i].ElementAt(index)}{input[i + 1].ElementAt(index + 1)}{input[i + 2].ElementAt(index + 2)}{input[i + 3].ElementAt(index + 3)}" == lookupWord)
                    count++;

            if ((input.Count - 1 - i) >= 3 && index >= 3)
                if ($"{input[i].ElementAt(index)}{input[i + 1].ElementAt(index - 1)}{input[i + 2].ElementAt(index - 2)}{input[i + 3].ElementAt(index - 3)}" == lookupWord)
                    count++;
        }
    }


}
