var text = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\test.txt").ToList();
new Part1(text).Solve();
new Part2(text).Solve();