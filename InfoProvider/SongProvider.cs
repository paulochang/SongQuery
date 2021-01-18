using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Genius.SDK;

namespace InfoProvider
{
    public class SongProvider : ISongProvider
    {
        public const string accessToken = "xxxxxx";
        public async Task<IEnumerable<string>> GetSongNames(string artist, IRestClient client = null)
        {
            client ??= new RestClient(accessToken);

            var results = await client.search.GetSearchResults(artist);
            var artistHit = results.response.hits.FirstOrDefault(hit =>
                string.Equals(hit.result.primary_artist.name, artist, StringComparison.InvariantCultureIgnoreCase));
            if (artistHit == null) return Enumerable.Empty<string>();

            var songsCollection = new List<string>();
            var artistId = artistHit.result.primary_artist.id.ToString();
            var songs = await client.artists.GetSongsById(artistId);
            while (songs.response.next_page.HasValue)
            {
                songsCollection.AddRange(songs.response.songs.Select(s => s.title));
                var nextPage = songs.response.next_page.Value;
                songs = await client.artists.GetSongsById(artistId, page: nextPage);
            }
            
            songsCollection.AddRange(songs.response.songs.Select(s => s.title));

            return songsCollection;
        }
    }
}