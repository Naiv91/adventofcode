public class Part1(List<string> input)
{
    public void Solve()
    {
        for (int i = 0; i < input.Count; i += 4)
        {
            (int x, int y) a = (int.Parse(input[i].Split(':')[1].Split(',')[0].Split('+')[1]), int.Parse(input[i].Split(':')[1].Split(',')[1].Split('+')[1]));
            (int x, int y) b = (int.Parse(input[i + 1].Split(':')[1].Split(',')[0].Split('+')[1]), int.Parse(input[i].Split(':')[1].Split(',')[1].Split('+')[1]));
            (int x, int y) prize = (int.Parse(input[i + 2].Split(':')[1].Split(',')[0].Split('+')[1]), int.Parse(input[i].Split(':')[1].Split(',')[1].Split('+')[1]));
        }
    }
}
