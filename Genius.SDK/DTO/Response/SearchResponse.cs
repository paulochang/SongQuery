using System.Collections.Generic;
using Genius.SDK.DTO.Search;

// ReSharper disable InconsistentNaming

namespace Genius.SDK.DTO.Response
{
    public class SearchResponse : BaseResponse
    {
        public InnerResponse response { get; set; }

        public class InnerResponse
        {
            public List<SearchResource> hits { get; set; }
        }
    }
}