using System.Collections.Generic;
using System.Text.Json.Serialization;
using Genius.SDK.DTO.Song;

// ReSharper disable InconsistentNaming

namespace Genius.SDK.DTO.Search
{
    public class SearchResource
    {
        public SongResource result { get; set; }
    }
}