using InfoProvider.Tests.FakeInstances;
using Xunit;

namespace InfoProvider.Tests
{
    public class SongProviderTests
    {
        [Fact]
        public async void shouldReturnBasicListOfSongs()
        {
            ISongProvider songProvider = new SongProvider();
            var songNames = await songProvider.GetSongNames("demoArtist", new FakeRestClient());
            var expectedSongs = new[] {"title 1", "title 2"};
            Assert.NotEmpty(songNames);
            Assert.Equal(expectedSongs, songNames);
        }

        [Fact]
        public async void shouldReturnEmptyListOfSongs()
        {
            ISongProvider songProvider = new SongProvider();
            var songNames = await songProvider.GetSongNames("nonExistentArtust", new FakeRestClient());
            Assert.Empty(songNames);
        }
    }
}