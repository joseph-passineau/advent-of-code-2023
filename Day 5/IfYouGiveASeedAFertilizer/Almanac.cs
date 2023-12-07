namespace IfYouGiveASeedAFertilizer;
public class Almanac
{
    private readonly List<long> seeds = [];
    private readonly List<DestinationSourceMap> seedToSoilMap = [];
    private readonly List<DestinationSourceMap> soilToFertilizerMap = [];
    private readonly List<DestinationSourceMap> fertilizerToWaterMap = [];
    private readonly List<DestinationSourceMap> waterToLightMap = [];
    private readonly List<DestinationSourceMap> lightToTempatureMap = [];
    private readonly List<DestinationSourceMap> tempatureToHumidityMap = [];
    private readonly List<DestinationSourceMap> humidityToLocationMap = [];

    public void AddSeeds(string value)
    {
        var seedsSplit = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach(var seed in seedsSplit)
        {
            seeds.Add(long.Parse(seed));
        }
    }

    public void AddSeedsRange(IEnumerable<long> values)
    {
        seeds.AddRange(values);
    }

    public void ClearSeeds()
    {
        seeds.Clear();
    }

    public void AddSeedToSoilMap(string map)
    {
        seedToSoilMap.Add(new DestinationSourceMap(map));
    }

    public void AddSoilToFertilizerMap(string map)
    {
        soilToFertilizerMap.Add(new DestinationSourceMap(map));
    }

    public void AddFertilizerToWaterMap(string map)
    {
        fertilizerToWaterMap.Add(new DestinationSourceMap(map));
    }

    public void AddWaterToLightMap(string map)
    {
        waterToLightMap.Add(new DestinationSourceMap(map));
    }

    public void AddLightToTempatureMap(string map)
    {
        lightToTempatureMap.Add(new DestinationSourceMap(map));
    }

    public void AddTempatureToHumidityMap(string map)
    {
        tempatureToHumidityMap.Add(new DestinationSourceMap(map));
    }

    public void AddHumidityToLocationMap(string map)
    {
        humidityToLocationMap.Add(new DestinationSourceMap(map));
    }

    public List<SeedResult> CalculateSeedsMapping(bool keepLowestLocationOnly = false)
    {
        var results = new List<SeedResult>();
        SeedResult lowestLocationSeed = new SeedResult(9999) { Location = long.MaxValue};

        foreach (var seed in seeds)
        {
            var seedResult = new SeedResult(seed);

            seedResult.Soil = new DestinationSourceMapper(seedToSoilMap).GetDestinationValue(seed);
            seedResult.Fertilizer = new DestinationSourceMapper(soilToFertilizerMap).GetDestinationValue(seedResult.Soil);
            seedResult.Water = new DestinationSourceMapper(fertilizerToWaterMap).GetDestinationValue(seedResult.Fertilizer);
            seedResult.Light = new DestinationSourceMapper(waterToLightMap).GetDestinationValue(seedResult.Water);
            seedResult.Temperature = new DestinationSourceMapper(lightToTempatureMap).GetDestinationValue(seedResult.Light);
            seedResult.Humidity = new DestinationSourceMapper(tempatureToHumidityMap).GetDestinationValue(seedResult.Temperature);
            seedResult.Location = new DestinationSourceMapper(humidityToLocationMap).GetDestinationValue(seedResult.Humidity);

            if(keepLowestLocationOnly)
            {
                if(seedResult.Location < lowestLocationSeed.Location)
                {
                    lowestLocationSeed = seedResult;
                }
            }
            else
            {
                results.Add(seedResult);
            }
        }

        if(keepLowestLocationOnly)
        {
            results.Add(lowestLocationSeed);
        }

        return results;
    }
}
