using Dvog.API.Contracts;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Dvog.IntegrationTests;

public class BlogControllerTests : BaseControllerTests
{
    public BlogControllerTests(ITestOutputHelper outputHelper) : base(outputHelper)
    {
    }

    [Fact] // Тест конкретного действия
    public async Task Create_ShouldReturnOK()
    {
        // Arrange
        var request = new CreateBlogRequest("testText", "testTitle");

        // Act
        var response = await Client.PostAsJsonAsync("/Blogs", request);

        // Assert
        Assert.NotNull(response);
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async void Create_ShouldReturnBadRequest()
    {
        // Arrange
        CreateBlogRequest request = null;

        // Act
        var response = await Client.PostAsJsonAsync("/Blogs", request);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}