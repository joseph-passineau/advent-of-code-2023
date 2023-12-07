namespace IfYouGiveASeedAFertilizer;
public class DestinationSourceMap
{
    private readonly long destination;
    private readonly long source;
    private readonly long range;

    public DestinationSourceMap(string value)
    {
        var mapSplit = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        destination = long.Parse(mapSplit[0]);
        source = long.Parse(mapSplit[1]);
        range = long.Parse(mapSplit[2]);
    }

    public long Difference => destination - source;

    public bool IsInSourceRange(long value)
    {
        return value >= source && value <= source + range;
    }
}
