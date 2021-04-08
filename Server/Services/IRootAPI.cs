using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Duck.Server.Model;
using Duck.Server.Responses;
using Duck.Shared;
using Refit;

namespace Duck.Server.Services
{
    public interface IRootAPI
    {
        [Get("/api/v2/court?apiKey=d68Uy7PMjD7t")]
        Task<RootResponse> GetResultAsync(Render root);
    }
}
