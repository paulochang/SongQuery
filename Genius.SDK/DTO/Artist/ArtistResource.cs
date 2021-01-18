// ReSharper disable InconsistentNaming

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Genius.SDK.DTO.Artist
{
    public class ArtistResource
    {
        public ulong id { get; set; }
        public string name { get; set; }
    }
}