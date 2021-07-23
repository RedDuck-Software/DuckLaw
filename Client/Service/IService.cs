using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Duck.Shared;
namespace Duck.Client.Service
{
    interface IService
    {
        Task<OpenDataBotModel> CreateNewBlogPost(OpenDataBotModel request);
        void ParsePage(ParsePage request);
        Task<string> GetFile();
    }
}
