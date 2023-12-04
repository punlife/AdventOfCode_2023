using AdventOfCode_2023.Day2;
using Newtonsoft.Json;

namespace AdventOfCode_2023_Tests.Day2;

public class Day2Test
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestLineProcessing()
    {
        // Arrange
        var testValue1 = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        var testValue2 = "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue";

        var expectedValue1 = new Game()
        {
            Id = 1,
            Sets = new List<GameSet>()
            {
                new GameSet() { Blue = 3, Green = 0, Red = 4 },
                new GameSet() { Blue = 6, Green = 2, Red = 1 },
                new GameSet() { Blue = 0, Green = 2, Red = 0 }
            }
        };
        var expectedValue2 = new Game()
        {
            Id = 2,
            Sets = new List<GameSet>()
            {
                new GameSet() { Blue = 1, Green = 2, Red = 0 },
                new GameSet() { Blue = 4, Green = 3, Red = 1 },
                new GameSet() { Blue = 1, Green = 1, Red = 0 }
            }
        };
        
        var dataLoader = new DataLoader();

        // Act
        var value1 = dataLoader.CreateGameFromInputLine(testValue1);
        var value2 = dataLoader.CreateGameFromInputLine(testValue2);


        // Assert
        AreEqualByJson(expectedValue1, value1);
        AreEqualByJson(expectedValue2, value2);
    }
    
    [Test]
    public void TestSetValidation()
    {
        // Arrange
        var testValue1 = new GameSet() { Blue = 12, Green = 7, Red = 4 };
        var testValue2 = new GameSet() { Blue = 17, Green = 7, Red = 4 };
        var testValue3 = new GameSet() { Blue = 3, Green = 15, Red = 17 };
        var testValue4 = new GameSet() { Blue = 3, Green = 11, Red = 19 };
        var testValue5 = new GameSet() { Blue = 3, Green = 11, Red = 1 };
        
        var gameValidator = new GameValidator(12, 14, 16);

        // Act
        // Assert
        Assert.That(gameValidator.IsSetValid(testValue1), Is.True);
        Assert.That(gameValidator.IsSetValid(testValue2), Is.False);
        Assert.That(gameValidator.IsSetValid(testValue3), Is.False);
        Assert.That(gameValidator.IsSetValid(testValue4), Is.False);
        Assert.That(gameValidator.IsSetValid(testValue5), Is.True);
    }
    
    [Test]
    public void TestReturnsPowers()
    {
        // Arrange
        var testValue1 = new Game()
        {
            Id = 1,
            Sets = new List<GameSet>()
            {
                new GameSet() { Blue = 3, Green = 0, Red = 4 },
                new GameSet() { Blue = 6, Green = 2, Red = 1 },
                new GameSet() { Blue = 0, Green = 2, Red = 0 }
            }
        };
        
        var gameValidator = new GameValidator(12, 14, 16);

        // Act
        var value = gameValidator.ReturnThePowersForGames(new List<Game>() { testValue1 });
        
        // Assert
        Assert.That(value[0], Is.EqualTo(6*2*4));

    }
    
    public static void AreEqualByJson(object expected, object actual)
    {
        var expectedJson = JsonConvert.SerializeObject(expected);
        var actualJson = JsonConvert.SerializeObject(actual);
        Assert.That(expectedJson, Is.EqualTo(actualJson));
    }
}