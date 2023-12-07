namespace IfYouGiveASeedAFertilizer;
public class DestinationSourceMapper
{
    private readonly List<DestinationSourceMap> map = [];

    public DestinationSourceMapper(List<DestinationSourceMap> map)
    {
        this.map = map;
    }

    public long GetDestinationValue(long source)
    {
        var destinationSourceMap = map.FirstOrDefault(x => x.IsInSourceRange(source));

        if(destinationSourceMap == null)
        {
            return source;
        }
        else
        {
            return source + destinationSourceMap.Difference;
        }
    }
}
