using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http; 
using System.Net.Http.Json;
using System.Threading.Tasks;
using Duck.Shared;
using Duck.Shared.Requests;
using Duck.Shared.Response;

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
            var result = await _http.PostAsJsonAsync("api/File", request);
            return await result.Content.ReadFromJsonAsync<OpenDataBotModel>();
        }

        public async Task<CourtSearchResultsResponse> SearchCourt(CourtSearchRequest request)
        {
            var result = await _http.PostAsJsonAsync("api/File/search-result", request);
            return await result.Content.ReadFromJsonAsync<CourtSearchResultsResponse>();
        }
        
        public async Task<string> GetFile()
        {
            var result = await _http.GetAsync("api/File");
            return await result.Content.ReadAsStringAsync();
        }
        public void ParsePage(ParsePage request)
        {
            var result = _http.PostAsJsonAsync("api/File/saveComment", request);
        }

    }
}
