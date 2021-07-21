using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Duck.Shared;
namespace Duck.Client.Service
{
    interface IService
    {
        Task<Render> CreateNewBlogPost(Render request);
        Task<string> ParsePage(ParsePage request);
        Task<string> GetFile();
    }
}
