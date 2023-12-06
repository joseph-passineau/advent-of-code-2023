namespace Scratchcards;
public class ScratchCardsProcessor
{
    private List<ScratchCard> cards;

    public ScratchCardsProcessor()
    {
        cards = new List<ScratchCard>();
    }

    public void AddCard(ScratchCard scratchCard)
    {
        cards.Add(scratchCard);
    }

    public List<ScratchCard> ProcessCards()
    {
        var processedCards = new List<ScratchCard>(cards);

        var numberOfOriginalCards = cards.Count;

        var originalCardIndex = 0;
        foreach (var originalCard in cards)
        {
            var cardsToProcess = processedCards.Where(x => x.Id == originalCard.Id).ToList();
            var cardWinningCount = cardsToProcess.First().WinningCount;

            for (var i = 1; i <= cardWinningCount; i++)
            {
                var originalCardToCopy = cards[originalCardIndex + i];
                var newCards = Enumerable.Repeat(originalCardToCopy, cardsToProcess.Count);
                processedCards.AddRange(newCards);
            }
            originalCardIndex++;
        }

        return processedCards;
    }

}
