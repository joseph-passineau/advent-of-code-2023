using System.Collections.Generic;

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
        var partNumbers = new List<PartNumber>();

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
                        partNumbers.Add(partNumber);
                        partNumber = new PartNumber();
                    }
                }
                charIndex++;
            }

            lineIndex++;
        }

        return partNumbers;
    }

    public List<Gear> GetGears()
    {
        var gears = new List<Gear>();

        var lineIndex = 0;
        foreach (var line in lines)
        {
            var charIndex = 0;
            foreach (var character in line)
            {
                if (character == '*')
                {
                    var gear = new Gear();
                    gear.AdjacentPartNumbers.AddRange(
                        FindAdjacentPartNumbers(lineIndex, charIndex).Select(x=> x.Number)
                    );
                    gears.Add(gear);
                }
                charIndex++;
            }
            lineIndex++;
        }

        return gears;
    }

    private List<PartNumber> FindAdjacentPartNumbers(int lineIndex, int charIndex)
    {
        var partNumbers = new List<PartNumber>();

        var topCenterChar = GetCharacterAt(lineIndex - 1, charIndex);
        if(char.IsNumber(topCenterChar)) 
        {
            partNumbers.Add(GetPartNumberAt(lineIndex - 1, charIndex));
        } 
        else 
        {
            var topLeft = GetCharacterAt(lineIndex - 1, charIndex -1);
            if (char.IsNumber(topLeft))
            {
                partNumbers.Add(GetPartNumberAt(lineIndex - 1, charIndex - 1));
            }

            var topRight = GetCharacterAt(lineIndex - 1, charIndex + 1);
            if (char.IsNumber(topRight))
            {
                partNumbers.Add(GetPartNumberAt(lineIndex - 1, charIndex + 1));
            }
        }

        var leftCenterChar = GetCharacterAt(lineIndex, charIndex -1);
        if (char.IsNumber(leftCenterChar))
        {
            partNumbers.Add(GetPartNumberAt(lineIndex, charIndex - 1));
        }

        var rightCenterChar = GetCharacterAt(lineIndex, charIndex + 1);
        if (char.IsNumber(rightCenterChar))
        {
            partNumbers.Add(GetPartNumberAt(lineIndex, charIndex + 1));
        }

        var lowerCenterChar = GetCharacterAt(lineIndex + 1, charIndex);
        if (char.IsNumber(lowerCenterChar))
        {
            partNumbers.Add(GetPartNumberAt(lineIndex + 1, charIndex));
        }
        else
        {
            var lowerLeft = GetCharacterAt(lineIndex + 1, charIndex - 1);
            if (char.IsNumber(lowerLeft))
            {
                partNumbers.Add(GetPartNumberAt(lineIndex + 1, charIndex - 1));
            }

            var lowerRight = GetCharacterAt(lineIndex + 1, charIndex + 1);
            if (char.IsNumber(lowerRight))
            {
                partNumbers.Add(GetPartNumberAt(lineIndex + 1, charIndex + 1));
            }
        }

        return partNumbers;
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
        var character = GetCharacterAt(lineIndex, charIndex);
        return !char.IsNumber(character) && character != '.';
    }

    private char GetCharacterAt(int lineIndex, int charIndex)
    {
        if (lineIndex >= 0 && lineIndex < lines.Count && charIndex >= 0 && charIndex < lines[lineIndex].Length)
        {
            return lines[lineIndex][charIndex];
        }
        return '.';
    }

    private PartNumber GetPartNumberAt(int lineIndex, int charIndex)
    {
        var partNumber = new PartNumber();

        var charPointer = charIndex;

        while (char.IsNumber(GetCharacterAt(lineIndex, charPointer - 1)))
        {
            charPointer -= 1;
        }

        while (char.IsNumber(GetCharacterAt(lineIndex, charPointer)))
        {
            partNumber.AddCharNumber(GetCharacterAt(lineIndex, charPointer));
            charPointer += 1;
        }

        return partNumber;
    }

}
