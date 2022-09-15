using System;
using System.Linq;
using System.Threading.Tasks;
using Exthand.Bitfinex.DTO;
using Exthand.Bitfinex.Shared.Helpers.Extensions;
using Exthand.Bitfinex.Shared.Interfaces.Action;
using Exthand.Bitfinex.Shared.Interfaces.Services;
using Exthand.BitFinex.Shared.Helpers.Extensions.Confguration;
using Microsoft.Extensions.Logging;

namespace Exthand.Bitfinex.App.Action
{
    public class ExthandJob : IExthandJob
    {
        private readonly ILogger<ExthandJob> _logger;
        private readonly IBitFinexService _bitFinexService;
        private static readonly string ClassName = typeof(ExthandJob).Name + " - ";
        private readonly AppConfig _appConfig;

        public ExthandJob(ILogger<ExthandJob> logger, IBitFinexService bitFinexService, AppConfig appConfig)
        {
            _logger = logger;
            _bitFinexService = bitFinexService;
            _appConfig = appConfig;
        }

        public async Task RunAsync()
        {
            try 
            {
                var currentDatetime = DateTime.UtcNow;

                var request = new ExthandTradeRequest 
                {
                    Start = Converter.ToEpochStart(currentDatetime.AddHours(-1)).ToString(),
                    End = Converter.ToEpochStart(currentDatetime).ToString(),
                    Symbol = _appConfig.CURRENCY_PAIR
                };

                var response = await _bitFinexService.GetTradesAsync(request);
                _logger.LogInformation($"Last executed at >> {DateTime.UtcNow} ");
                _logger.LogInformation($"Average Price Min >> {response.Min(x => x.Price)}");
                _logger.LogInformation($"Average Price Max >> {response.Max(x => x.Price)}");
            }
            catch(Exception ex)
            {
                _logger.LogError(ClassName + "Error GetTradesAsync: " + ex.StackTrace);
            }
        }
    }
}
