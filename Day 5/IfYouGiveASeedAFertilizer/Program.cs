// See https://aka.ms/new-console-template for more information
using IfYouGiveASeedAFertilizer;

Console.WriteLine("Advent of Code - Day 5");

var almanac = new Almanac();
var currentSection = string.Empty;

foreach (string line in File.ReadLines("input.txt"))
{
    if(string.IsNullOrWhiteSpace(line)) continue;

    var splitTitleString = line.Split(':');

    if(splitTitleString.Length == 2)
    {
        var title = splitTitleString[0].Trim();

        if (title == "seeds")
        {
            almanac.AddSeeds(splitTitleString[1]);
        }
        else 
        {
            currentSection = title.Trim();
        }
    }
    else
    {
        switch (currentSection)
        {
            case "seed-to-soil map":
                almanac.AddSeedToSoilMap(line);
                break;
            case "soil-to-fertilizer map":
                almanac.AddSoilToFertilizerMap(line);
                break;
            case "fertilizer-to-water map":
                almanac.AddFertilizerToWaterMap(line);
                break;
            case "water-to-light map":
                almanac.AddWaterToLightMap(line);
                break;
            case "light-to-temperature map":
                almanac.AddLightToTempatureMap(line);
                break;
            case "temperature-to-humidity map":
                almanac.AddTempatureToHumidityMap(line);
                break;
            case "humidity-to-location map":
                almanac.AddHumidityToLocationMap(line);
                break;
            default:
                throw new Exception($"Unknown title: {currentSection}");
        }
    }
}

var seedResults = almanac.CalculateSeedsMapping();
var lowestLocation = seedResults.Min(s => s.Location);

Console.WriteLine("The lowest location number is: {0}", lowestLocation);