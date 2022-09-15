using Exthand.BitFinex.Shared.Helpers.Extensions.Confguration;
using RestSharp;

namespace Exthand.BitFinex.Shared.Helpers.Http.Request
{
    public class BitFinexRequest : RestRequest
    {
        private readonly AppConfig _config;

        public BitFinexRequest(AppConfig appConfig)
        {
            _config = appConfig;
        }

        public BitFinexRequest Create(string path, Method method, int timeout = 300000)
        {
            base.Resource = _config.BitFinex_API_URI + path;
            base.Method = method;
            base.Timeout = timeout;
            base.RequestFormat = DataFormat.Json;

            return this;
        }
    }
}
