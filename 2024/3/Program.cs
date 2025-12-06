using _3;

var text = File.ReadAllText(Directory.GetCurrentDirectory() + "\\input.txt");
new Part1(text).Solve();
new Part2(text).Solve();