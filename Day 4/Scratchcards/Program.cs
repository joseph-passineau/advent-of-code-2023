
using Scratchcards;

Console.WriteLine("Advent of Code - Day 4");

var pileOfCardsTotal = 0;
var scratchCardsProcessor = new ScratchCardsProcessor();
foreach (string line in File.ReadLines(@"input.txt"))
{
    var scratchCard = new ScratchCard(line);
    pileOfCardsTotal += scratchCard.Points;
    scratchCardsProcessor.AddCard(scratchCard);
}

var processedCards = scratchCardsProcessor.ProcessCards();

Console.WriteLine($"Pile of cards is worth: {pileOfCardsTotal}");
Console.WriteLine($"Total number of scratchcards processed: {processedCards.Count}");