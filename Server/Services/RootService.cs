using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Duck.Server.Model;
using Duck.Server.Responses;
using Duck.Shared;
using HttpClientDiagnostics;

using Refit;
using static Duck.Server.Controllers.Model;

namespace Duck.Server.Services
{
    public class RootService
    {
        private readonly HttpClient _httpClient;
        private readonly IRootAPI _rootAPI;

        public RootService(Uri baseUrl)
        {
            _httpClient = new HttpClient(new HttpClientDiagnosticsHandler(new HttpClientHandler())) { BaseAddress = baseUrl };
            _rootAPI = RestService.For<IRootAPI>(_httpClient);
        }

        public async Task<RootResponse> SearchAsync(OpenDataBotModel root)
        {
            return await _rootAPI.GetResultAsync(root).ConfigureAwait(false);
        }
    }
}
