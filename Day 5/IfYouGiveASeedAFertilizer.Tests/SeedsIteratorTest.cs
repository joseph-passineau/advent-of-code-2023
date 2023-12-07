namespace IfYouGiveASeedAFertilizer.Tests;
public class SeedsIteratorTest
{
    [Fact]
    public void SeedReader_Should_Return_Correct_Seeds()
    {
        // Arrange

        var seedsIterator = new SeedsIterator("79 14 55 13");
        var sumOfSeeds = 0;

        // Act

        foreach (var item in seedsIterator)
        {
            sumOfSeeds += item.Count();
        }

        // Assert

        Assert.Equal(27, sumOfSeeds);
    }

    [Fact]
    public void SeedReader_Should_Support_VeryBig_Seeds()
    {
        // Arrange

        var seedsIterator = new SeedsIterator("1848591090 462385043 2611025720 154883670 1508373603 11536371 3692308424 16905163 1203540561 280364121 3755585679 337861951 93589727 738327409 3421539474 257441906 3119409201 243224070 50985980 7961058");
        var sumOfSeeds = 0;

        // Act

        foreach (var item in seedsIterator)
        {
            sumOfSeeds += item.Count();
        }

        // Assert

        Assert.Equal(1263936319, sumOfSeeds);
    }
}
