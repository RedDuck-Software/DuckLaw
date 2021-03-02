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
        [Get("/api/v2/court?apiKey=UyVcQj3XzGaN&{request}")]
        Task<Root> GetResult([Body] Render request);
    }
}
