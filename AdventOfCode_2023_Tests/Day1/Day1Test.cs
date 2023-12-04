using AdventOfCode_2023.Day1;

namespace AdventOfCode_2023_Tests.Day1;

public class Day1Test
{
    
    [SetUp]
    public void Setup()
    {
        
    }
    
    [Test]
    public void TestLineProcessing()
    {
        // Arrange
        var testValue1 = "1abc2";
        var testValue2 = "a1b2c3d4e5f";
        var textProcessor = new TextProcessor();

        // Act
        var value1 = textProcessor.ProcessLine(testValue1);
        var value2 = textProcessor.ProcessLine(testValue2);
        
        // Assert
        Assert.That(value1, Is.EqualTo(12));
        Assert.That(value2, Is.EqualTo(15));
    }
    
    [Test]
    [Ignore("unused idea")]
    public void TestWordReplacing()
    {
        // Arrange
        var testValue1 = "two1nine";
        var testValue2 = "abcone2threexyz";
        var textProcessor = new TextProcessor();

        // Act
        var value1 = textProcessor.ConvertWordsToNumbers(testValue1);
        var value2 = textProcessor.ConvertWordsToNumbers(testValue2);
        
        // Assert
        Assert.That(value1, Is.EqualTo("219"));
        Assert.That(value2, Is.EqualTo("abc123xyz"));
    }
    
      
    [Test]
    [Ignore("unused idea")]
    public void TestSubstringListCreation()
    {
        // Arrange
        var testValue1 = "on2a";
        var expectedValues = new List<string>()
        {
            "o","n","2", "a",
            
            
            "on", "on2", "on2a",
           "n2", "n2a",
             "2a",
           
        };
        var textProcessor = new TextProcessor();

        // Act
        var value1 = textProcessor.CreateAListOfSubstringsOfValue(testValue1);
        
        // Assert
        Assert.That(value1, Is.EqualTo(expectedValues));

    }
    
    [Test]
    public void TestStringTraversal()
    {
        // Arrange
        var testValue1 = "xtwone3four";
        var textProcessor = new TextProcessor();

        // Act
        var value1 = textProcessor.TraverseTheStringToGetValues(testValue1);
        
        // Assert
        Assert.That(value1, Is.EqualTo("24"));

    }
    
    
    
    [Test]
    public void TestTextProcessorT1()
    {
        // Arrange
        var testValue1 = "1abc2";
        var testValue2 = "a1b2c3d4e5f";
        var textProcessor = new TextProcessor();

        // Act
        var value1 = textProcessor.ProcessTaskOneText(new []{ testValue1 });
        var value2 = textProcessor.ProcessTaskOneText(new []{ testValue2 });
        
        // Assert
        Assert.That(value1, Is.EqualTo(12));
        Assert.That(value2, Is.EqualTo(15));
    }
    
    [Test]
    public void TestTextProcessorT2()
    {
        // Arrange
        var testValue1 = "two1nine";
        var testValue2 = "abcone2threexyz";
        var testValue3 = "xtwone3four";
        
            
        var textProcessor = new TextProcessor();

        // Act
        var value1 = textProcessor.ProcessTaskTwoText(new []{ testValue1 });
        var value2 = textProcessor.ProcessTaskTwoText(new []{ testValue2 });
        var value3 = textProcessor.ProcessTaskTwoText(new []{ testValue3 });
        
        // Assert
        Assert.That(value1, Is.EqualTo(29));
        Assert.That(value2, Is.EqualTo(13));
        Assert.That(value3, Is.EqualTo(24));
    }
}