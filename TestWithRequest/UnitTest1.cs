using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockHttp;
using MockHttp.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestWithRequest
{
    [TestClass]
    public class UnitTest1
    {
        MockHttpHandler mockHttp = new MockHttpHandler();
        [TestInitialize]
        public void Mock()
        {
            mockHttp
                .When(matching => matching
                    .Method("GET")
                    .RequestUri("https://opendatabot.com/api/v2/court?apiKey=d68Uy7PMjD7t")
                )
                .RespondJson(HttpStatusCode.OK, new { id = 123, firstName = "John", lastName = "Doe" })
                .Verifiable();
        }
        [TestMethod]
        public async Task TestMethod1()
        {
            var client = new HttpClient(mockHttp);
            var response = await client.GetAsync("https://opendatabot.com/api/v2/court?apiKey=d68Uy7PMjD7t");
            response.Content.Should().NotBeNull();
            mockHttp.Verify();
        }
    }
}
