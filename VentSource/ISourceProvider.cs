using System.Collections.Generic;
using System.Threading.Tasks;

namespace VentSource
{
    public interface ISourceProvider
    {
        Task<long> UpdateSourcesAsync(List<Source> sources);
    }
}
