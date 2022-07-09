using Dvog.API.Contracts;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Dvog.IntegrationTests;

public class AuthorControllerTests
{
    [Fact]
    public async Task Create_ShouldReturnOK()
    {
        // Arrange
        var application = new WebApplicationFactory<Program>();
        var client = application.CreateClient();

        var request = new CreateAuthorRequest("testUserName");

        // Act
        var response = await client.PostAsJsonAsync("/Author", request);

        // Assert
        Assert.NotNull(response);
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async void Create_ShouldReturnBadRequest()
    {
        // Arrange
        var application = new WebApplicationFactory<Program>();
        var client = application.CreateClient();

        CreateAuthorRequest request = null;

        // Act
        var response = await client.PostAsJsonAsync("/Author", request);

        // Assert
        bool isNotWork = false;

        try
        {
            // Assert.NotNull(response);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            isNotWork = true;
        }

        Assert.True(isNotWork);
    }
}