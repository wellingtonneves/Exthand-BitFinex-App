using Exthand.BitFinex.Shared.Helpers.Extensions.Confguration;
using Exthand.BitFinex.Shared.Helpers.Http.Request;
using RestSharp;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Exthand.Bitfinex.Shared.Helpers.Extensions;

namespace Exthand.Bitfinex.Shared.Helpers.Http.ClientProvider
{
    public class BitFinexClientProvider : RestClient 
    {
        private readonly AppConfig _config;

        public BitFinexClientProvider(AppConfig config)
        {
            _config = config;            
        }

        public async Task<RestResponse<T>> ExecuteAsync<T>(RestRequest request, CancellationToken cancellationToken)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            base.BuildUri(request);

            RestResponse<T> response;
            var result = await base.ExecuteAsync(request, new CancellationTokenSource().Token);
            response = Converter.Deserialize<T>(result);

            stopWatch.Stop();
            
            return response;
        }

        public BitFinexRequest GetRequest()
        {
            return new BitFinexRequest(_config);
        }
    }
}
