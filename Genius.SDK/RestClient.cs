using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Genius.SDK.Endpoints;
using Genius.SDK.Endpoints.Impl;

namespace Genius.SDK
{
    public class RestClient : IRestClient
    {
        public IArtistsEndpoint artists { get; }
        public ISearchEndpoint search { get; }

        private readonly Configuration _configuration;
        private string _accessToken;
#if DEBUG
        private static readonly HttpClient HttpClient = new HttpClient(new LoggingHandler(new HttpClientHandler()));
#else
        private static readonly HttpClient HttpClient = new();
#endif
        public RestClient(string accessToken) : this(accessToken, new Configuration())
        {
        }

        public RestClient(string accessToken, string baseURI) : this(accessToken, new Configuration())
        {
            _configuration.BaseUri = new Uri(baseURI);
        }

        public RestClient(string accessToken, Configuration configuration, HttpClient httpClient = null)
        {
            httpClient ??= HttpClient;
            _accessToken = accessToken;
            _configuration = configuration;
            httpClient.Timeout = configuration.TimeOut;
            httpClient.BaseAddress = configuration.BaseUri;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            artists = new ArtistsEndpoint(httpClient);
            search = new SearchEndpoint(httpClient);
        }
    }
}