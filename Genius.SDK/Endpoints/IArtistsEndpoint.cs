using System.Threading.Tasks;
using Genius.SDK.DTO.Response;

namespace Genius.SDK.Endpoints
{
    public interface IArtistsEndpoint
    {
        Task<ArtistsSongsResponse> GetSongsById(string id, string sort = null, int perPage = 50,
            ulong? page = null);
    }
}