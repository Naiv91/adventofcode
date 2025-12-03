using _2_25;

var text = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\input.txt").ToList();
await new Part1(text, CancellationToken.None).Solve();
// new Part2(text).Solve();