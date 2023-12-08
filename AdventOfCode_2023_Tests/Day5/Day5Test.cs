using AdventOfCode_2023.Day3;
using AdventOfCode_2023.Day4;
using AdventOfCode_2023.Day5;
using Newtonsoft.Json;

namespace AdventOfCode_2023_Tests.Day5;

public class Day5Test
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
            "seeds: 79 14 55 13",
            "",
            "seed-to-soil map:",
            "50 98 2",
            "52 50 48",
            "",
            "soil-to-fertilizer map:",
            "0 15 37",
            "37 52 2",
            "39 0 15",
            "",
            "fertilizer-to-water map:",
            "49 53 8",
            "0 11 42",
            "42 0 7",
            "57 7 4",
            "",
            "water-to-light map:",
            "88 18 7",
            "18 25 70",
            "",
            "light-to-temperature map:",
            "45 77 23",
            "81 45 19",
            "68 64 13",
            "",
            "temperature-to-humidity map:",
            "0 69 1",
            "1 0 69",
            "",
            "humidity-to-location map:",
            "60 56 37",
            "56 93 4"
        };

        // Act
        var dayRunner = new Day5Runner();
        var result = dayRunner.ExecuteTask1(testInput);
        
        // Assert
        Assert.That(result, Is.EqualTo(35));
    }
    
    [Test]
    public void TestT2()
    {
        // Arrange
        var testInput = new[]
        {
            "seeds: 79 14 55 13",
            "",
            "seed-to-soil map:",
            "50 98 2",
            "52 50 48",
            "",
            "soil-to-fertilizer map:",
            "0 15 37",
            "37 52 2",
            "39 0 15",
            "",
            "fertilizer-to-water map:",
            "49 53 8",
            "0 11 42",
            "42 0 7",
            "57 7 4",
            "",
            "water-to-light map:",
            "88 18 7",
            "18 25 70",
            "",
            "light-to-temperature map:",
            "45 77 23",
            "81 45 19",
            "68 64 13",
            "",
            "temperature-to-humidity map:",
            "0 69 1",
            "1 0 69",
            "",
            "humidity-to-location map:",
            "60 56 37",
            "56 93 4"
        };

        // Act
        var dayRunner = new Day5Runner();
        var result = dayRunner.ExecuteTask2(testInput);
        
        // Assert
        Assert.That(result, Is.EqualTo(46));
    }

    
    public static void AreEqualByJson(object expected, object actual)
    {
        var expectedJson = JsonConvert.SerializeObject(expected);
        var actualJson = JsonConvert.SerializeObject(actual);
        Assert.That(expectedJson, Is.EqualTo(actualJson));
    }
}