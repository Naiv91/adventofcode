using _3_25;

var text = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\input.txt").ToList();
// await new Part1(text, CancellationToken.None).Solve();
await new Part2(text, CancellationToken.None).Solve();