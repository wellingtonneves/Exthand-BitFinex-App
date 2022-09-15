using Exthand.Bitfinex.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exthand.Bitfinex.Shared.Interfaces.Repositories
{
    public interface IBitFinexRepository
    {
        Task<IEnumerable<string[]>> GetTradesAsync(ExthandTradeRequest request);
    }
}
