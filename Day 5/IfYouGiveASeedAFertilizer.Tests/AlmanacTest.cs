namespace IfYouGiveASeedAFertilizer.Tests;

public class AlmanacTest
{
    [Fact]
    public void Almanac_Should_Return_Valid_Results_When_CalculateSeedsMapping()
    {
        // Arrange
        var almanac = new Almanac();

        almanac.AddSeeds("79 14 55 13");

        almanac.AddSeedToSoilMap("50 98 2");
        almanac.AddSeedToSoilMap("52 50 48");

        almanac.AddSoilToFertilizerMap("0 15 37");
        almanac.AddSoilToFertilizerMap("37 52 2");
        almanac.AddSoilToFertilizerMap("39 0 15");

        almanac.AddFertilizerToWaterMap("49 53 8");
        almanac.AddFertilizerToWaterMap("0 11 42");
        almanac.AddFertilizerToWaterMap("42 0 7");
        almanac.AddFertilizerToWaterMap("57 7 4");

        almanac.AddWaterToLightMap("88 18 7");
        almanac.AddWaterToLightMap("18 25 70");

        almanac.AddLightToTempatureMap("45 77 23");
        almanac.AddLightToTempatureMap("81 45 19");
        almanac.AddLightToTempatureMap("68 64 13");

        almanac.AddTempatureToHumidityMap("0 69 1");
        almanac.AddTempatureToHumidityMap("1 0 69");

        almanac.AddHumidityToLocationMap("60 56 37");
        almanac.AddHumidityToLocationMap("56 93 4");

        // Act

        var seedResults = almanac.CalculateSeedsMapping();

        // Assert

        Assert.Equal(4, seedResults.Count());
        Assert.Equal(82, seedResults[0].Location);
        Assert.Equal(43, seedResults[1].Location);
        Assert.Equal(86, seedResults[2].Location);
        Assert.Equal(35, seedResults[3].Location);
    }

    [Fact]
    public void Almanac_Should_Return_Valid_Results_When_CalculateSeedsMapping_WithKeepingOnlyLowest()
    {
        // Arrange
        var almanac = new Almanac();

        almanac.AddSeeds("79 14 55 13");

        almanac.AddSeedToSoilMap("50 98 2");
        almanac.AddSeedToSoilMap("52 50 48");

        almanac.AddSoilToFertilizerMap("0 15 37");
        almanac.AddSoilToFertilizerMap("37 52 2");
        almanac.AddSoilToFertilizerMap("39 0 15");

        almanac.AddFertilizerToWaterMap("49 53 8");
        almanac.AddFertilizerToWaterMap("0 11 42");
        almanac.AddFertilizerToWaterMap("42 0 7");
        almanac.AddFertilizerToWaterMap("57 7 4");

        almanac.AddWaterToLightMap("88 18 7");
        almanac.AddWaterToLightMap("18 25 70");

        almanac.AddLightToTempatureMap("45 77 23");
        almanac.AddLightToTempatureMap("81 45 19");
        almanac.AddLightToTempatureMap("68 64 13");

        almanac.AddTempatureToHumidityMap("0 69 1");
        almanac.AddTempatureToHumidityMap("1 0 69");

        almanac.AddHumidityToLocationMap("60 56 37");
        almanac.AddHumidityToLocationMap("56 93 4");

        // Act

        var seedResults = almanac.CalculateSeedsMapping(true);

        // Assert

        Assert.Single(seedResults);
        Assert.Equal(35, seedResults[0].Location);
    }
}