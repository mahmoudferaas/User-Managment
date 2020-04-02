using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xunit;

namespace Presentation.Tests
{
    public class GraphQlTests
    {
        private readonly string _baseUrl = "http://localhost:63989/graphql/";

        [Fact]
        public async void Users_PassingValidQuery_ReturnsValidResults()
        {
            using var client = new HttpClient();
            var requestBody = "{\"query\":\"{\\r\\n  user(args:{query:\\\"{ \\\\\\\"match_all\\\\\\\" :  {} }\\\"})\\r\\n  {\\r\\n    userId\\r\\n  }\\r\\n}\\r\\n\\r\\n\"}";
            HttpContent content = new StringContent(requestBody, Encoding.Default, "application/json");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var requestResponse = await client.PostAsync(_baseUrl, content);
            var json = await requestResponse.Content.ReadAsStringAsync();

            Assert.Contains("userId", json);
        }
    }
}
