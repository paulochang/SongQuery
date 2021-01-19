using System.Net.Http;
using Genius.SDK;
using Xunit;

namespace InfoProvider.IntegrationTests
{
    public class SongProviderIntegrationTest
    {
        [Fact]
        public async void ShouldProvideListWithPagination()
        {
            ISongProvider songProvider = new SongProvider();
            var songNames = await songProvider.GetSongNames("grimes",
                new RestClient("", new Configuration(), new HttpClient(new FakeServerSimulator())));
            var expectedSongs = new[]
            {
                "4ÆM", "4 AM (Demo)",
                "Adieu / Into You (Acapella) / Kalimankou Denkou (The Evening Gathering) [Acapella]",
                "Aeon / Kill V. Maim / Di-Li-Do (Acapella)", "After All / Cozy Girl"
            };
            Assert.NotEmpty(songNames);
            Assert.Equal(expectedSongs, songNames);
        }
    }
}