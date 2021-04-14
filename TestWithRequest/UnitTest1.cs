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
    public class UnitTest1
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

            #region ResponseJS
            /*{{
                "status": "all right",
                "data": {
                  "count": 2,
                  "items": [
                    {
                      "link": "https://opendatabot.com/api/v2/"
                    }
                  ]
                }
              }}*/
            #endregion
            var responseResult = JToken.Parse(await response.Content.ReadAsStringAsync());

            _mockHttpRequest.Verify();
            response.Content.Should().NotBeNull();
            responseResult["data"]["items"].Should().HaveCount(1);
            responseResult["data"]["count"].ToString().Should().Be("2");
            responseResult["data"]["items"].Should().NotBeNullOrEmpty();
            responseResult["status"].ToString().Should().Be("all right");
            responseResult["data"]["items"][0]["link"].ToString().Should().Be("https://opendatabot.com/api/v2/");
        }

        private RootResponse MockDataResponse => new RootResponse
        {
            status = "all right",
            data = new Data
            {
                count = 2,
                items = new List<Item>
                {
                    new Item { link = "https://opendatabot.com/api/v2/"}
                }
            }
        };
    }
}
