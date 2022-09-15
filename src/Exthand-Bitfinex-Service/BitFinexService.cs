using Exthand.Bitfinex.DTO;
using Exthand.Bitfinex.Shared.Interfaces.Repositories;
using Exthand.Bitfinex.Shared.Interfaces.Services;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Globalization;

namespace Exthand.Bitfinex.Service
{
    public class BitFinexService : IBitFinexService
    {
        private readonly IBitFinexRepository _bitFinexRepository;

        public BitFinexService(IBitFinexRepository bitFinexRepository)
        {
            _bitFinexRepository = bitFinexRepository;
        }

        public async Task<IEnumerable<ExthandTradeResponse>> GetTradesAsync(ExthandTradeRequest request)
        {
            var tradeList = await _bitFinexRepository.GetTradesAsync(request);

            var response = new List<ExthandTradeResponse>();

            foreach(var trade in tradeList) 
            {
                var item = new ExthandTradeResponse
                {
                    Id = long.Parse(trade[0]),
                    Mts = long.Parse(trade[1]),
                    Amount = decimal.Parse(trade[2], CultureInfo.InvariantCulture),
                    Price = decimal.Parse(trade[3], CultureInfo.InvariantCulture)
                };

                response.Add(item);
            }
                
            return response;
        }
    }
}
