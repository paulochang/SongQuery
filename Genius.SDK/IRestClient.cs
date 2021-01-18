using Genius.SDK.Endpoints;

namespace Genius.SDK
{
    public interface IRestClient
    {
        IArtistsEndpoint artists { get; }
        ISearchEndpoint search { get; }
    }
}