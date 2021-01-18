using Genius.SDK;
using Genius.SDK.Endpoints;

namespace InfoProvider.Tests.FakeInstances
{
    public class FakeRestClient : IRestClient
    {
        public FakeRestClient()
        {
            artists = new FakeArtistsEndpoint();
            search = new FakeSearchEndpoint();
        }

        public IArtistsEndpoint artists { get; }
        public ISearchEndpoint search { get; }
    }
}