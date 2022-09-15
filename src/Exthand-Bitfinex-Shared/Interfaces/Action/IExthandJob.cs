using System.Threading.Tasks;

namespace Exthand.Bitfinex.Shared.Interfaces.Action
{
    public interface IExthandJob
    {
        Task RunAsync();
    }
}
