using System.Collections.Generic;
using System.Threading.Tasks;
using Genius.SDK;

namespace InfoProvider
{
    public interface ISongProvider
    {
        Task<IEnumerable<string>> GetSongNames(string artist, IRestClient client = null);
    }
}