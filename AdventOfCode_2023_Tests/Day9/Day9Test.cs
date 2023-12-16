using AdventOfCode_2023.Day6;
using AdventOfCode_2023.Day7;
using AdventOfCode_2023.Day9;
using Newtonsoft.Json;

namespace AdventOfCode_2023_Tests.Day9;

public class Day9Test
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
            "0 3 6 9 12 15",
            "1 3 6 10 15 21",
            "10 13 16 21 30 45"
        };

        // Act
        var dayRunner = new Day9Runner();
        var result = dayRunner.ExecuteTask1(testInput);

        // Assert
        Assert.That(result, Is.EqualTo(114));
    }

    [Test]
    public void TestT2()
    {
        // Arrange
        var testInput = new[]
        {
            "0 3 6 9 12 15",
            "1 3 6 10 15 21",
            "10 13 16 21 30 45"
        };

        // Act
        var dayRunner = new Day9Runner();
        var result = dayRunner.ExecuteTask2(testInput);

        // Assert
        Assert.That(result, Is.EqualTo(2));
    }


    public static void AreEqualByJson(object expected, object actual)
    {
        var expectedJson = JsonConvert.SerializeObject(expected);
        var actualJson = JsonConvert.SerializeObject(actual);
        Assert.That(expectedJson, Is.EqualTo(actualJson));
    }
}