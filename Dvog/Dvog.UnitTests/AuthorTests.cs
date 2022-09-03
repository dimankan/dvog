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
}