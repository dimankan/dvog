using Dvog.API.Contracts;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;


namespace Dvog.IntegrationTests;

public class AuthorControllerTests : BaseControllerTests
{
    public AuthorControllerTests(ITestOutputHelper outputHelper) : base(outputHelper)
    {
    }

    [Fact]
    public async Task Create_ShouldReturnOK()
    {
        // Arrange
        var request = new CreateAuthorRequest("testUserName");

        // Act
        var response = await Client.PostAsJsonAsync("/Author", request);

        // Assert
        Assert.NotNull(response);
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async void Create_ShouldReturnBadRequest()
    {
        // Arrange
        CreateAuthorRequest request = null;

        // Act
        var response = await Client.PostAsJsonAsync("/Author", request);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}