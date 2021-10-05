using System.Threading.Tasks;
using Duck.Shared;
using Duck.Shared.Requests;
using Duck.Shared.Response;

namespace Duck.Client.Service
{
    interface IService
    {
        Task<OpenDataBotModel> CreateNewBlogPost(OpenDataBotModel request);

        Task<CourtSearchResultsResponse> SearchCourt(CourtSearchRequest request);
        
        void ParsePage(ParsePage request);
        Task<string> GetFile();
    }
}
