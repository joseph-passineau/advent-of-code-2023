namespace Scratchcards;
public class ScratchCard
{
    public ScratchCard(string value)
    {
        var splitCard = value.Split(':');
        var numberSplit = splitCard[1].Split('|');

        Id = int.Parse(splitCard[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
        WinningNumbers = numberSplit[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        Numbers = numberSplit[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
    }

    public int Id { get; set; }

    public List<int> WinningNumbers { get; set; }

    public List<int> Numbers { get; set; }

    public int WinningCount => WinningNumbers.Intersect(Numbers).Count();

    public int Points => (int)Math.Pow(2, WinningCount - 1);
}
