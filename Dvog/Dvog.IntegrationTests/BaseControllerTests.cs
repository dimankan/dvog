using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Xunit.Abstractions;

namespace Dvog.IntegrationTests
{
    public class BaseControllerTests
    {
        public BaseControllerTests(ITestOutputHelper outputHelper)
        {
            var application = new WebApplicationFactory<Program>();
            Client = application.CreateDefaultClient(new LoggingHandler(outputHelper));
        }

        /// <summary>
        /// 
        /// </summary>
        protected HttpClient Client { get; }
    }
}
