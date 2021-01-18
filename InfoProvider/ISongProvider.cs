using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoProvider
{
    public interface ISongProvider
    {
        Task<IEnumerable<string>> GetSongNames(string artist);
    }
}