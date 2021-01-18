using InfoProvider.Tests.FakeInstances;
using Xunit;

namespace InfoProvider.Tests
{
    public class MainTests
    {
        [Fact]
        public async void shouldReturnBasicListOfSongs()
        {
            ISongProvider songProvider = new SongProvider();
            var songNames = await songProvider.GetSongNames("demoArtst", new FakeRestClient());
            Assert.NotEmpty(songNames);
        }
    }
}