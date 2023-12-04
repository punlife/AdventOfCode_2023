using AdventOfCode_2023.Day2;
using AdventOfCode_2023.Day3;
using Newtonsoft.Json;

namespace AdventOfCode_2023_Tests.Day3;

public class Day3Test
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestSchemaCreation()
    {
        // Arrange
        var testValue1 = new[]
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."
        };

        // Act
        var engine = new EngineMap(new SchematicValidator(), testValue1);


        // Assert
        for (var i = 0; i < testValue1.Length; i++)
        {
            var testLine = testValue1[i];
            for (int j = 0; j < testLine.Length; j++)
            {
                Assert.That(engine.Schematic[i, j], Is.EqualTo(testLine[j]));
            }
        }
    }

    [Test]
    public void TestMapTraversal()
    {
        // Arrange
        var testInput = new[]
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."
        };
        var expectedValues = new List<string>()
        {
            "467", "35", "633", "617", "592", "755", "664", "598"
        };
        var validator = new SchematicValidator();
        validator.PopulateAllowedCharacters(testInput);
        var engine = new EngineMap(validator, testInput);

        // Act
        var partNumbers = engine.TraverseMap();

        // Assert
        Assert.That(partNumbers.Count, Is.EqualTo(8));
        CollectionAssert.AreEquivalent(expectedValues, partNumbers);
    }

    [Test]
    public void TestCompleteT1()
    {
        // Arrange
        var testInput = new[]
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."
        };
        var expectedValue = 4361;

        // Act
        var runner = new Day3Runner();
        var result = runner.ReturnSum(testInput);

        // Assert
        Assert.That(result, Is.EqualTo(expectedValue));
    }
    
    [Test]
    public void TestCompleteT2()
    {
        // Arrange
        var testInput = new[]
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."
        };
        var expectedValue = 467835;

        // Act
        var runner = new Day3Runner();
        var result = runner.ReturnGear(testInput);

        // Assert
        Assert.That(result, Is.EqualTo(expectedValue));
    }
    
    [Test]
    public void TestLastPositionEdgeCase()
    {
        // Arrange
        var testInput = new[]
        {
            "467..114.5",
            "...*.....*",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."
        };
        var expectedValue = 4366;

        // Act
        var runner = new Day3Runner();
        var result = runner.ReturnSum(testInput);

        // Assert
        Assert.That(result, Is.EqualTo(expectedValue));
    }

    public static void AreEqualByJson(object expected, object actual)
    {
        var expectedJson = JsonConvert.SerializeObject(expected);
        var actualJson = JsonConvert.SerializeObject(actual);
        Assert.That(expectedJson, Is.EqualTo(actualJson));
    }
}