using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Dvog.IntegrationTests
{
    public class LoggingHandler : DelegatingHandler
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public LoggingHandler(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _testOutputHelper.WriteLine(request.Method + " " + request.RequestUri);
            await PrintContent(request.Content);
            var response = await base.SendAsync(request, cancellationToken);
            await PrintContent(response.Content);
            return response;
        }

        private async Task PrintContent(HttpContent? content)
        {
            if (content == null)
            {
                return;
            }

            var body = await content.ReadAsStringAsync();

            try
            {
                var json = JToken.Parse(body).ToString();
                _testOutputHelper.WriteLine(json);
            }
            catch
            {
                _testOutputHelper.WriteLine(body);
            }
        }
    }
}
