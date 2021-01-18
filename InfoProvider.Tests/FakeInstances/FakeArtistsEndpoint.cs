using System.Collections.Generic;
using System.Threading.Tasks;
using Genius.SDK.DTO.Response;
using Genius.SDK.DTO.Song;
using Genius.SDK.Endpoints;

namespace InfoProvider.Tests.FakeInstances
{
    public class FakeArtistsEndpoint : IArtistsEndpoint
    {
        public Task<ArtistsSongsResponse> GetSongsById(string id, string sort = null, int perPage = 50,
            ulong? page = null)
        {
            var artistsSongsResponse = new ArtistsSongsResponse
            {
                meta = new BaseResponse.Meta
                {
                    status = 200
                },
                response = new ArtistsSongsResponse.InnerResponse
                {
                    songs = new List<SongResource>
                    {
                        new()
                        {
                            title = "title 1"
                        },
                        new()
                        {
                            title = "title 2"
                        }
                    }
                }
            };
            return Task.FromResult(artistsSongsResponse);
        }
    }
}