using System.Collections.Generic;
using System.Text.Json.Serialization;
using Genius.SDK.DTO.Artist;

// ReSharper disable InconsistentNaming

namespace Genius.SDK.DTO.Song
{
    public class SongResource
    {
        public string title { get; set; }

        public ArtistResource primary_artist { get; set; }
    }
}