using System.Collections.Generic;
using Genius.SDK.DTO.Song;

// ReSharper disable InconsistentNaming

namespace Genius.SDK.DTO.Response
{
    public class ArtistsSongsResponse : BaseResponse
    {
        public InnerResponse response { get; set; }

        public class InnerResponse
        {
            public List<SongResource> songs { get; set; }

            public ulong? next_page { get; set; }
        }
    }
}