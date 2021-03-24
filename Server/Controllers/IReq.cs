using Duck.Shared;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Duck.Server.Controllers.Model;

namespace Duck.Server.Controllers
{
    public interface Ireq
    {
        [Get("/api/v2/court?apiKey=d68Uy7PMjD7t&{request}")]
        Task<Root> GetResult([Body] Render request);
    }
}
