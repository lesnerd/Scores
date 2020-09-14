using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    public interface IFlowProvider
    {
        Task Execute(IFileLocationProvider locationProvider);
    }
}