using GearRatios;

Console.WriteLine("Advent of Code - Day 3");

var engineSchematic = new EngineSchematic();

foreach (string line in File.ReadLines(@"input.txt"))
{
    engineSchematic.AddLine(line);
}

var sumOfAllValidParts = engineSchematic.GetPartNumbers().Where(x => x.IsValid).Sum(x => x.Number);
var sumOfAllGearsRatio = engineSchematic.GetGears().Where(x => x.IsValid).Sum(x => x.Ratio);

Console.WriteLine($"The sum of all the valid part numbers is: {sumOfAllValidParts}");
Console.WriteLine($"The sum of all ratio of valid gears is: {sumOfAllGearsRatio}");