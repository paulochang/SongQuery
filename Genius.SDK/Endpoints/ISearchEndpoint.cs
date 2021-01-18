using System.Threading.Tasks;
using Genius.SDK.DTO.Response;

namespace Genius.SDK.Endpoints
{
    public interface ISearchEndpoint
    {
        Task<SearchResponse> GetSearchResults(string query);
    }
}