using AdventOfCode_2023.Day10;
using AdventOfCode_2023.Day6;
using AdventOfCode_2023.Day7;
using AdventOfCode_2023.Day9;
using Newtonsoft.Json;

namespace AdventOfCode_2023_Tests.Day10;

public class Day10Test
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestT1()
    {
        // Arrange
        var testInput = new[]
        {
            "LLR",
            "",
            "AAA = (BBB, BBB)",
            "BBB = (AAA, ZZZ)",
            "ZZZ = (ZZZ, ZZZ)"
        };

        // Act
        var result = new Day10Runner().ExecuteTask1(testInput);

        // Assert
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void TestT2()
    {
        // Arrange
        var testInput = new[]
        {
            "LR",
            "",
            "11A = (11B, XXX)",
            "11B = (XXX, 11Z)",
            "11Z = (11B, XXX)",
            "22A = (22B, XXX)",
            "22B = (22C, 22C)",
            "22C = (22Z, 22Z)",
            "22Z = (22B, 22B)",
            "XXX = (XXX, XXX)"
        };

        // Act
        var result = new Day10Runner().ExecuteTask2(testInput);

        // Assert
        Assert.That(result, Is.EqualTo(6));
    }


    public static void AreEqualByJson(object expected, object actual)
    {
        var expectedJson = JsonConvert.SerializeObject(expected);
        var actualJson = JsonConvert.SerializeObject(actual);
        Assert.That(expectedJson, Is.EqualTo(actualJson));
    }
}