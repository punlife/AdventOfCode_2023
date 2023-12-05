using AdventOfCode_2023.Day3;
using AdventOfCode_2023.Day4;
using Newtonsoft.Json;

namespace AdventOfCode_2023_Tests.Day4;

public class Day4Test
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestExampleInput()
    {
        // Arrange
        var testInput = new[]
        {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
        };

        // Act
        var scratchcardValidator = new ScratchcardValidator();
        var scratchcards = ScratchcardLoader.CreateScratchcardsFromInput(testInput);
        var result = scratchcardValidator.ValidateScratchcards(scratchcards);
        
        // Assert
        Assert.That(result, Is.EqualTo(13));
    }
    
    [Test]
    public void TestT2()
    {
        // Arrange
        var testInput = new[]
        {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
        };

        // Act
        var scratchcardValidator = new ScratchcardValidator();
        var scratchcards = ScratchcardLoader.CreateScratchcardDictionaryFromInput(testInput);
        var result = scratchcardValidator.ValidateScratchcardsT2(scratchcards);
        
        // Assert
        Assert.That(result, Is.EqualTo(30));
    }
    
    public static void AreEqualByJson(object expected, object actual)
    {
        var expectedJson = JsonConvert.SerializeObject(expected);
        var actualJson = JsonConvert.SerializeObject(actual);
        Assert.That(expectedJson, Is.EqualTo(actualJson));
    }
}