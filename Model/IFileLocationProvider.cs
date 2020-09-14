using System.Collections.Generic;
using System.Threading.Tasks;

namespace Model
{
    public interface IFileLocationProvider
    {
        Task<IList<SourceLocations>> GetLocation();

    }
}