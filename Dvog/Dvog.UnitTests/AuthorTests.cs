using Dvog.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace Dvog.UnitTests;

public class AuthorTests
{
    [Fact]
    public void Create_ShouldReturnAuthor()
    {
        // Arrange
        string userName = "dimankan";

        // Act
        var authorResult = Author.Create(userName);

        // Assert
        Assert.False(authorResult.IsFailure);
    }

    [Fact]
    public void Create_InvalidData_ShouldReturnErrorResult()
    {
        // Arrange
        string userName = string.Empty;
        // Act
        var authorResult = Author.Create(userName);

        // Assert
        Assert.True(authorResult.IsFailure);
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