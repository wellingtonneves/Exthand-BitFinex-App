using Exthand.BitFinex.Shared.Helpers.Extensions.Confguration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Exthand.Bitfinex.Shared.Helpers.Extensions
{
    public static class ConfigHelper
    {
        public static AppConfig ConfigureApi(this IServiceCollection services) 
        {
            AppConfig appConfig;

            appConfig = new AppConfig
            {
                BitFinex_API_URI = Environment.GetEnvironmentVariable("BitFinex_API_URI"),
                CURRENCY_PAIR = Environment.GetEnvironmentVariable("CURRENCY_PAIR"),
                SCHEDULE_INTERVAL = int.Parse(Environment.GetEnvironmentVariable("SCHEDULE_INTERVAL"))
            };

            services.AddSingleton(appConfig);

            return appConfig;
        }
    }
}
