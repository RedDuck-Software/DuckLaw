using Duck.Server.Responses;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockHttp;
using MockHttp.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestWithRequest
{
    [TestClass]
    public class Response_test
    {
        private MockHttpHandler _mockHttpRequest;
        private readonly string BaseUri = "https://opendatabot.com/api/v2/court?apiKey=d68Uy7PMjD7t";

        [TestInitialize]
        public void Mock()
        {
            _mockHttpRequest = new MockHttpHandler();

            _mockHttpRequest.When(matching => matching.Method("GET").RequestUri(BaseUri))
                .RespondJson(HttpStatusCode.OK, MockDataResponse)
                .Verifiable();
        }

        [TestMethod]
        public async Task GetMockDataReponseFormFakeRequestAsyncTest()
        {
            var client = new HttpClient(_mockHttpRequest);
            var response = await client.GetAsync(BaseUri);
            var responseResult = JToken.Parse(await response.Content.ReadAsStringAsync());

            _mockHttpRequest.Verify();
            response.Content.Should().NotBeNull();
            responseResult["items"].Should().HaveCount(1);
            responseResult["count"].ToString().Should().Be("1");
            responseResult["items"].Should().NotBeNullOrEmpty();
            responseResult["status"].ToString().Should().Be("all right");
            responseResult["items"][0]["link"].ToString().Should().Be("https://opendatabot.ua/court/76195512-b22b9fbfbb31d6aca70b89d1257287a4");
        }

        private RootResponse MockDataResponse => new RootResponse
        {
            Status = "all right",
            Count = 1,
            Items = new List<Item> { new Item() {Link = "https://opendatabot.ua/court/76195512-b22b9fbfbb31d6aca70b89d1257287a4" } }
           
        };
    }
}
