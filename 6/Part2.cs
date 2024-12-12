public class Part2(List<string> input)
{
    public void Solve()
    {
        List<char> directions = ['^', '>', 'v', '<'];

        Console.WriteLine(Enumerable.Range(0, input.Count).SelectMany(y => Enumerable.Range(0, input[0].Length).Select(x => (x, y))).Count(cord => CheckPatrole((cord.x, cord.y))));

        bool CheckPatrole((int x, int y) obstacle)
        {
            var currentGrid = input.Select(y => y.Select(x => x).ToList()).ToList();
            
            if (currentGrid[obstacle.y][obstacle.x] == '.')
                currentGrid[obstacle.y][obstacle.x] = '#';
            
            var currentPos = Enumerable.Range(0, currentGrid.Count).SelectMany(y => Enumerable.Range(0, currentGrid[0].Count).Select(x => (x, y))).First(pos => directions.Contains(currentGrid[pos.y][pos.x]));
            var direction = currentGrid[currentPos.y][currentPos.x];

            List<(int x, int y, int dirIndex)> visited = [];

            while (true)
            {
                if (visited.Any(v => v.x == currentPos.x && v.y == currentPos.y && v.dirIndex == directions.IndexOf(direction)))
                {
                    return true;
                }
                visited.Add((currentPos.x, currentPos.y, directions.IndexOf(direction)));

                var nextPos = Step(currentPos);

                if (nextPos.x < 0 || nextPos.x == currentGrid[0].Count || nextPos.y < 0 || nextPos.y == currentGrid.Count)
                {
                    break;
                }

                if (currentGrid[nextPos.y][nextPos.x] == '#')
                {
                    direction = directions[directions.IndexOf(direction) + 1 == directions.Count ? 0 : directions.IndexOf(direction) + 1];
                }
                else
                {
                    currentPos = nextPos;
                }
            }

            return false;

            (int x, int y) Step((int x, int y) nextPos)
            {
                switch (direction)
                {
                    case '^':
                        nextPos.y--;
                        break;
                    case '>':
                        nextPos.x++;
                        break;
                    case 'v':
                        nextPos.y++;
                        break;
                    default:
                        nextPos.x--;
                        break;
                }

                return nextPos;
            }
        } 
    }
}
