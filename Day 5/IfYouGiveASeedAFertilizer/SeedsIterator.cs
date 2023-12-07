using System.Collections;

namespace IfYouGiveASeedAFertilizer;
public class SeedsIterator : IEnumerable<IEnumerable<long>>
{
    Dictionary<long, long> seedsRanges = [];

    public SeedsIterator(string line)
    {
        var splitSeeds = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (var i = 0; i < splitSeeds.Length; i = i + 2)
        {
            var seedNumber = long.Parse(splitSeeds[i]);
            var seedAmount = long.Parse(splitSeeds[i + 1]);
            seedsRanges.Add(seedNumber, seedAmount);
        }
    }

    public IEnumerator<IEnumerable<long>> GetEnumerator()
    {
        foreach (var seedsRange in seedsRanges)
        {
            yield return CreateRange(seedsRange.Key, seedsRange.Value);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    private IEnumerable<long> CreateRange(long start, long count)
    {
        var limit = start + count;

        while (start < limit)
        {
            yield return start;
            start++;
        }
    }
}
