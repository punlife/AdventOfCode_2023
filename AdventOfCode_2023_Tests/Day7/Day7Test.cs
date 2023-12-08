﻿using AdventOfCode_2023.Day6;
using AdventOfCode_2023.Day7;
using Newtonsoft.Json;

namespace AdventOfCode_2023_Tests.Day7;

public class Day7Test
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
            "32T3K 765",
            "T55J5 684",
            "KK677 28",
            "KTJJT 220",
            "QQQJA 483"
        };

        // Act
        var dayRunner = new Day7Runner();
        var result = dayRunner.ExecuteTask1(testInput);

        // Assert
        Assert.That(result, Is.EqualTo(6440));
    }

    [Test]
    public void TestT2()
    {
        // Arrange
        var testInput = new[]
        {
            "32T3K 765",
            "T55J5 684",
            "KK677 28",
            "KTJJT 220",
            "QQQJA 483"
        };

        // Act
        var dayRunner = new Day7Runner();
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