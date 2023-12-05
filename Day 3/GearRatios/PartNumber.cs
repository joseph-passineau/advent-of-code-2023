namespace GearRatios;
public class PartNumber
{
    private string stringNumber = "";

    public PartNumber()
    {
        stringNumber = string.Empty;
    }

    public int Number => string.IsNullOrEmpty(stringNumber) ? 0 : int.Parse(stringNumber);

    public bool IsValid { get; set; }

    public void AddCharNumber(char character)
    {
        stringNumber += character;
    }
}
