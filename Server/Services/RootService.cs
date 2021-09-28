using System;
using System.Net.Http;
using System.Threading.Tasks;
using Duck.Server.Responses;
using Duck.Shared;
using HttpClientDiagnostics;
using MockHttp;
using Refit;

namespace Duck.Server.Services
{
    public class RootService
    {
        private readonly HttpClient _httpClient;
        private readonly IRootAPI _rootAPI;

        public RootService(Uri baseUrl, MockHttpHandler mockclient)
        {
            _httpClient = new HttpClient(mockclient) { BaseAddress = baseUrl };
            _rootAPI = RestService.For<IRootAPI>(_httpClient);
        }

        public async Task<RootResponse> SearchAsync(OpenDataBotModel root)
        {
            return await _rootAPI.GetResultAsync(root).ConfigureAwait(false);
        }
    }
}
