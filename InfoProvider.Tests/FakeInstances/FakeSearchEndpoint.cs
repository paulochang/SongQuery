using System.Collections.Generic;
using System.Threading.Tasks;
using Genius.SDK.DTO.Artist;
using Genius.SDK.DTO.Response;
using Genius.SDK.DTO.Search;
using Genius.SDK.DTO.Song;
using Genius.SDK.Endpoints;

namespace InfoProvider.Tests.FakeInstances
{
    public class FakeSearchEndpoint : ISearchEndpoint
    {
        public Task<SearchResponse> GetSearchResults(string query)
        {
            var searchResponse = new SearchResponse
            {
                meta = {status = 200},
                response = new SearchResponse.InnerResponse
                {
                    hits = new List<SearchResource>
                    {
                        new()
                        {
                            result = new SongResource
                            {
                                primary_artist = new ArtistResource
                                {
                                    id = 1,
                                    name = "demoArtist"
                                }
                            }
                        },
                        new()
                        {
                            result = new SongResource
                            {
                                primary_artist = new ArtistResource
                                {
                                    id = 2,
                                    name = "demoArtist2"
                                }
                            }
                        }
                    }
                }
            };

            return Task.FromResult(searchResponse);
        }
    }
}