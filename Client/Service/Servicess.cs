using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http; 
using System.Net.Http.Json;
using System.Threading.Tasks;
using Duck.Shared;

namespace Duck.Client.Service
{
    public class Servicess : IService
    {
        private readonly HttpClient _http;
        public Servicess(HttpClient http)
        {
            _http = http;
        }
        public async Task<OpenDataBotModel> CreateNewBlogPost(OpenDataBotModel request)
        {
            var result = await _http.PostAsJsonAsync("api/User", request);
            return await result.Content.ReadFromJsonAsync<OpenDataBotModel>();
        }
        public async Task<string> GetFile()
        {
            var result = await _http.GetAsync("api/User");
            return await result.Content.ReadAsStringAsync();
        }
        public void ParsePage(ParsePage request)
        {
            var result = _http.PostAsJsonAsync("api/User/parse", request);
        }

    }
}
