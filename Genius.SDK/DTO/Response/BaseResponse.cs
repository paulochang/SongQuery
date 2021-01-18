// ReSharper disable InconsistentNaming

namespace Genius.SDK.DTO.Response
{
    public class BaseResponse
    {
        public Meta meta { get; set; }

        public class Meta
        {
            public ulong status { get; set; }
            public string message { get; set; }
        }
    }
}