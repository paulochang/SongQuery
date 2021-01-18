using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Genius.SDK.Common;
using Genius.SDK.DTO.Response;

namespace Genius.SDK.Endpoints.Impl
{
    public class SearchEndpoint : ISearchEndpoint
    {
        private static HttpClient _httpClient;
        private const string ResourceUri = "/search/";

        public SearchEndpoint(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SearchResponse> GetSearchResults(string query)
        {
            var uriHelper = new UriHelper(ResourceUri);
            uriHelper.AddQueryParameter("q", query);

            var requestUri = uriHelper.ToString();

            try
            {
                var hits = await _httpClient.GetFromJsonAsync<SearchResponse>(requestUri);

                return hits;
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