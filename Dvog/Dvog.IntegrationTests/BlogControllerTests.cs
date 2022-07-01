using Dvog.API.Contracts;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
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

        //var request = new CreateBlogRequest() { Text = "testText", Title = "testTitle" };      
        var request = new CreateBlogRequest("testText", "testTitle");

        // Act
        var response = await client.PostAsJsonAsync("/Blogs", request);

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

        // CreateBlogRequest request = new CreateBlogRequest { Text = "testText", Title = "testTitle" };
        CreateBlogRequest request = null;

        // Act
        var response = await client.PostAsJsonAsync("/Blogs", request);

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