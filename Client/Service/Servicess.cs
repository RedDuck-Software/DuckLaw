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
        public async Task<Render> CreateNewBlogPost(Render request)
        {
            var result = await _http.PostAsJsonAsync("api/User", request);
            return await result.Content.ReadFromJsonAsync<Render>();
        }
        public async Task<Render> GetDoc()
        {
            var resut = await _http.GetAsync("api/User");
            var message = await resut.Content.ReadAsStringAsync();
            return await resut.Content.ReadFromJsonAsync<Render>();
        }
    }
}
