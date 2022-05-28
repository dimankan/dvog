using Dvog.API.Contracts;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Dvog.IntegrationTests;

public class BlogControllerTests
{
    [Fact]
    public async Task Create_ShouldReturnOK()
    {
        // Arrange
        var application = new WebApplicationFactory<Program>();
        var client = application.CreateClient();

        var request = new CreateBlogRequest {Text = "testText", Title = "testTitle" };

        // Act
        var response = await client.PostAsJsonAsync("/Blogs", request);

        // Assert
        Assert.NotNull(response);
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public void Update_ShouldReturnBadRequest()
    {

    }
}