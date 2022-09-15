using Exthand.Bitfinex.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exthand.Bitfinex.Shared.Interfaces.Services
{
    public interface IBitFinexService
    {
        Task<IEnumerable<ExthandTradeResponse>> GetTradesAsync(ExthandTradeRequest request);
    }
}
