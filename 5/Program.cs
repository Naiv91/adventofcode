﻿using _5;

var text = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\input.txt").ToList();
new Part1(text).Solve();
new Part2(text).Solve();