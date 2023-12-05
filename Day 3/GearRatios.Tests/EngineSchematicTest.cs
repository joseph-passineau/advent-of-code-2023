namespace GearRatios.Tests;

public class EngineSchematicTest
{
    [Fact]
    public void EngineSchematic_Should_ReturnValidPartNumbers()
    {
        // Arrange
        var engineSchematic = new EngineSchematic();

        engineSchematic.AddLine("467..114..");
        engineSchematic.AddLine("...*......");
        engineSchematic.AddLine("..35..633.");
        engineSchematic.AddLine("......#...");
        engineSchematic.AddLine("617*......");
        engineSchematic.AddLine(".....+.58.");
        engineSchematic.AddLine("..592.....");
        engineSchematic.AddLine("......755.");
        engineSchematic.AddLine("...$.*....");
        engineSchematic.AddLine(".664.598..");

        // Act

        var validPartNumbers = engineSchematic.GetPartNumbers();

        // Assert
        Assert.Equal(10, validPartNumbers.Count);

        Assert.Equal(467, validPartNumbers[0].Number);
        Assert.True(validPartNumbers[0].IsValid);

        Assert.Equal(114, validPartNumbers[1].Number);
        Assert.False(validPartNumbers[1].IsValid);

        Assert.Equal(35, validPartNumbers[2].Number);
        Assert.True(validPartNumbers[2].IsValid);

        Assert.Equal(633, validPartNumbers[3].Number);
        Assert.True(validPartNumbers[3].IsValid);

        Assert.Equal(617, validPartNumbers[4].Number);
        Assert.True(validPartNumbers[4].IsValid);

        Assert.Equal(58, validPartNumbers[5].Number);
        Assert.False(validPartNumbers[5].IsValid);

        Assert.Equal(592, validPartNumbers[6].Number);
        Assert.True(validPartNumbers[6].IsValid);

        Assert.Equal(755, validPartNumbers[7].Number);
        Assert.True(validPartNumbers[7].IsValid);

        Assert.Equal(664, validPartNumbers[8].Number);
        Assert.True(validPartNumbers[8].IsValid);

        Assert.Equal(598, validPartNumbers[9].Number);
        Assert.True(validPartNumbers[9].IsValid);
    }

    [Fact]
    public void EngineSchematic_Should_ReturnGears()
    {
        // Arrange
        var engineSchematic = new EngineSchematic();

        engineSchematic.AddLine("467..114..");
        engineSchematic.AddLine("...*......");
        engineSchematic.AddLine("..35..633.");
        engineSchematic.AddLine("......#...");
        engineSchematic.AddLine("617*......");
        engineSchematic.AddLine(".....+.58.");
        engineSchematic.AddLine("..592.....");
        engineSchematic.AddLine("......755.");
        engineSchematic.AddLine("...$.*....");
        engineSchematic.AddLine(".664.598..");

        // Act

        var gears = engineSchematic.GetGears();

        // Assert
        Assert.Equal(3, gears.Count);

        Assert.True(gears[0].IsValid);
        Assert.Equal(16345, gears[0].Ratio);

        Assert.False(gears[1].IsValid);

        Assert.True(gears[2].IsValid);
        Assert.Equal(451490, gears[2].Ratio);
    }
}