using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Genius.SDK.Common;
using Genius.SDK.DTO.Response;

namespace Genius.SDK.Endpoints.Impl
{
    public class ArtistsEndpoint : IArtistsEndpoint
    {
        private const string ResourceUri = "/artists/";
        private static HttpClient _httpClient;

        public ArtistsEndpoint(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ArtistsSongsResponse> GetSongsById(string id, string sort = null, int perPage = 50,
            ulong? page = null)
        {
            const string subEndPoint = "/songs";
            var resourceUri = ResourceUri + id + subEndPoint;

            var uriHelper = new UriHelper(resourceUri);
            uriHelper.AddQueryParameter("sort", sort);
            uriHelper.AddQueryParameter("per_page", perPage.ToString());
            uriHelper.AddQueryParameter("page", page.ToString());

            var requestUri = uriHelper.ToString();

            try
            {
                var artistsSongs = await _httpClient.GetFromJsonAsync<ArtistsSongsResponse>(requestUri);

                return artistsSongs;
            }
            catch (HttpRequestException) // Non success
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an unexpected exceptions");
                Console.WriteLine(e);
            }

            return null;
        }
    }
}