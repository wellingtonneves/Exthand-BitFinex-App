using Exthand.Bitfinex.DTO;
using Exthand.Bitfinex.Shared.Helpers.Http.ClientProvider;
using Exthand.Bitfinex.Shared.Interfaces.Repositories;
using Exthand.BitFinex.Shared.Helpers.Extensions.Confguration;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Exthand.BitFinex.Shared.Helpers.Http.Request;
using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Exthand.BitFinex.Repository
{
    public class BitFinexRepository : IBitFinexRepository
    {
        private readonly AppConfig _appConfig;
        private readonly ILogger<BitFinexRepository> _logger;
        private BitFinexClientProvider _restClientFactory;

        private BitFinexClientProvider BitFinexClientProvider
        {
            get
            {
                if (_restClientFactory == null)
                    _restClientFactory = new BitFinexClientProvider(_appConfig);

                return _restClientFactory;

            }
        }

        public BitFinexRepository(
            AppConfig appConfig,
            ILogger<BitFinexRepository> logger)
        {
            _appConfig = appConfig;
            _logger = logger;
        }

        public async Task<IEnumerable<string[]>> GetTradesAsync(ExthandTradeRequest request)
        {
            BitFinexRequest httpRequest = BitFinexClientProvider.GetRequest().Create($"trades/{request.Symbol}/hist", Method.Get, 100000);

            httpRequest.AddQueryParameter("start", $"{request.Start}");
            httpRequest.AddQueryParameter("end", $"{request.End}");
            
            var response = await BitFinexClientProvider.ExecuteAsync<IEnumerable<dynamic>>(httpRequest);

            return JsonConvert.DeserializeObject<IEnumerable<string[]>>(response.Content);
        }
    }
}
