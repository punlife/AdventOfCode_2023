using AdventOfCode_2023.Day5;
using AdventOfCode_2023.Day6;
using Newtonsoft.Json;

namespace AdventOfCode_2023_Tests.Day6;

public class Day6Test
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
            "Time:      7  15   30 ",
            "Distance:  9  40  200 "
        };

        // Act
        var dayRunner = new Day6Runner();
        var result = dayRunner.ExecuteTask1(testInput);
        
        // Assert
        Assert.That(result, Is.EqualTo(288));
    }
    
    [Test]
    public void TestT2()
    {
        // Arrange
        var testInput = new[]
        {
            "Time:      71530 ",
            "Distance:  940200 "
        };

        // Act
        var dayRunner = new Day6Runner();
        var result = dayRunner.ExecuteTask2(testInput);
        
        // Assert
        Assert.That(result, Is.EqualTo(71503));
    }

    
    public static void AreEqualByJson(object expected, object actual)
    {
        var expectedJson = JsonConvert.SerializeObject(expected);
        var actualJson = JsonConvert.SerializeObject(actual);
        Assert.That(expectedJson, Is.EqualTo(actualJson));
    }
}