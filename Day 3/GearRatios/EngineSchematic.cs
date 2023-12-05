namespace GearRatios;
public class EngineSchematic
{
    private List<string> lines = new List<string>();

    public void AddLine(string line)
    {
        lines.Add(line);
    }

    public List<PartNumber> GetPartNumbers()
    {
        var validPartNumbers = new List<PartNumber>();

        var partNumber = new PartNumber();

        var lineIndex = 0;
        foreach (var line in lines)
        {
            var charIndex = 0;
            foreach (var character in line)
            {
                if(char.IsNumber(character))
                {
                    partNumber.AddCharNumber(character);
                    if(!partNumber.IsValid)
                    {
                        partNumber.IsValid = CheckIfPartNumberIsValid(lineIndex, charIndex);
                    }
                } else {
                    if(partNumber.Number > 0)
                    {
                        validPartNumbers.Add(partNumber);
                        partNumber = new PartNumber();
                    }
                }
                charIndex++;
            }

            lineIndex++;
        }

        return validPartNumbers;
    }

    private bool CheckIfPartNumberIsValid(int lineIndex, int charIndex)
    {
        return IsSymbol(lineIndex -1, charIndex -1) 
            || IsSymbol(lineIndex - 1, charIndex)
            || IsSymbol(lineIndex - 1, charIndex + 1)
            || IsSymbol(lineIndex, charIndex - 1)
            || IsSymbol(lineIndex, charIndex + 1)
            || IsSymbol(lineIndex + 1, charIndex - 1)
            || IsSymbol(lineIndex + 1, charIndex)
            || IsSymbol(lineIndex + 1, charIndex + 1);
    }

    private bool IsSymbol(int lineIndex, int charIndex)
    {
        if(lineIndex >= 0 && lineIndex < lines.Count && charIndex >= 0 && charIndex < lines[lineIndex].Length)
        {
            var character = lines[lineIndex][charIndex];
            return !char.IsNumber(character) && character != '.';
        }
        return false;
    }

}
