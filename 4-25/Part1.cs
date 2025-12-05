using System.Diagnostics;
using System.Runtime.InteropServices;

namespace _4_25;

public partial class Part1(List<string> input)
{
    public void Solve()
    {
        int accessableRolls = 0;

        var grid = input.Select(y => y.Select(x => x.ToString()).ToList()).ToList();
        Enumerable.Range(0, grid.Count).SelectMany(y => Enumerable.Range(0, grid[0].Count).Select(x => (x, y))).ToList().ForEach(cord =>
        {
            if (grid[cord.y][cord.x] != "@")
                return;

            int emptySlot = 0;

            // up
            if (IsEmptyOrOutOfBounds(cord.y - 1,cord.x))
                emptySlot++;

            // up right
            if (IsEmptyOrOutOfBounds(cord.y - 1, cord.x + 1))
                emptySlot++;

            // right
            if (IsEmptyOrOutOfBounds(cord.y,cord.x + 1))
                emptySlot++;

            // down right
            if (IsEmptyOrOutOfBounds(cord.y + 1, cord.x + 1))
                emptySlot++;

            // down
            if (IsEmptyOrOutOfBounds(cord.y + 1, cord.x))
                emptySlot++;

            // down left
            if (IsEmptyOrOutOfBounds(cord.y + 1, cord.x - 1))
                emptySlot++;

            // left
            if (IsEmptyOrOutOfBounds(cord.y, cord.x - 1))
                emptySlot++;

            // up left
            if (IsEmptyOrOutOfBounds(cord.y - 1, cord.x - 1))
                emptySlot++;

            if (emptySlot > 4)
            {
                accessableRolls++;
            }

            bool IsEmptyOrOutOfBounds(int y, int x)
            {
                if (y < 0 || y >= grid.Count)
                    return true;
                if (x < 0 || x >= grid[0].Count)
                    return true;

                return grid[y][x] == ".";
            }
        });

        Console.WriteLine($"{accessableRolls}");
    }
}
