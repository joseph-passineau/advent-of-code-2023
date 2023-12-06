namespace Scratchcards.Tests;
public class ScratchCardsProcessorTest
{
    [Fact]
    public void ScratchCardsProcessor_Should_Return_Correct_Amount_Of_Cards()
    {
        // Arrange

        var cardProcessor = new ScratchCardsProcessor();
        cardProcessor.AddCard(new ScratchCard("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53"));
        cardProcessor.AddCard(new ScratchCard("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19"));
        cardProcessor.AddCard(new ScratchCard("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1"));
        cardProcessor.AddCard(new ScratchCard("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83"));
        cardProcessor.AddCard(new ScratchCard("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36"));
        cardProcessor.AddCard(new ScratchCard("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"));

        // Act

        var processedCards = cardProcessor.ProcessCards();

        // Assert
        Assert.Equal(30, processedCards.Count);
    }
}
