namespace GearRatios;
public class Gear
{
    public List<int> AdjacentPartNumbers = new List<int>();

    public bool IsValid => AdjacentPartNumbers.Count == 2;

    public int Ratio => IsValid ? AdjacentPartNumbers[0] * AdjacentPartNumbers[1] : 0;
}
