using Dvog.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace Dvog.UnitTests;

public class BlogTests
{
    [Fact]
    public void Create_ShouldReturnBlog()
    {
        // Arrange
        string title = "title";
        string text = "text";

        // Act
        var blogResult = Blog.Create(title, text);

        // Assert
        Assert.False(blogResult.IsFailure);
    }

    [Theory]
    //[InlineData("title", "")]
    //[InlineData("", "text")]
    //[InlineData("", "")]
    [MemberData(nameof(Generate))]
    public void Create_InvalidData_ShouldReturnErrorResult(string title, string text)
    {
        // Arrange
        //string title = string.Empty;
        //string text = "text";

        // Act
        var blogResult = Blog.Create(title, text);

        // Assert
        Assert.True(blogResult.IsFailure);
    }

    private static IEnumerable<object[]> Generate()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new[] { string.Empty, Guid.NewGuid().ToString() };
            yield return new[] { Guid.NewGuid().ToString(), string.Empty }; 
        }
    }

    public static string GenerateString(int lengthString)
    {
        string result = String.Empty;

        char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuwxyz".ToCharArray();
        char[] numbers = "0123456789".ToCharArray();
        char[] symbols = ";.,-_".ToCharArray();

        List<char> list = new List<char>();
        list.AddRange(letters);
        list.AddRange(numbers);
        list.AddRange(symbols);

        Random rand = new Random();

        for (int i = 0; i < lengthString; i++)
        {
            result += list[rand.Next(0, list.Count - 1)];
        }

        return result;
    }
}