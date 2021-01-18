using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Genius.SDK.Endpoints;
using Genius.SDK.Endpoints.Impl;

namespace Genius.SDK
{
    public class RestClient
    {
        public IArtistsEndpoint artists;
        public ISearchEndpoint search;
        
        private Configuration _configuration;
        private string _accessToken;
#if DEBUG
        private static readonly HttpClient HttpClient = new HttpClient(new LoggingHandler(new HttpClientHandler()));
#else
        private static readonly HttpClient HttpClient = new HttpClient();
#endif
        public RestClient(String accessToken) : this(accessToken, new Configuration())
        {
        }

        public RestClient(String accessToken, String baseURI) : this(accessToken, new Configuration())
        {
            _configuration.BaseUri = new Uri(baseURI);
        }

        public RestClient(String accessToken, Configuration configuration)
        {
            _accessToken = accessToken;
            _configuration = configuration;
            HttpClient.Timeout = configuration.TimeOut;
            HttpClient.BaseAddress = configuration.BaseUri;
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            artists = new ArtistsEndpoint(HttpClient);
            search = new SearchEndpoint(HttpClient);
        }
    }
}