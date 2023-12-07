using Microsoft.Extensions.DependencyInjection;
using System;

namespace Best.Buy.API.Settings
{
    public static class ConfigHelper
    {
        public static AppConfig ConfigureApi(this IServiceCollection services)
        {
            AppConfig appConfig;

            appConfig = new AppConfig
            {
                KeyName = Environment.GetEnvironmentVariable("KEY_NAME"),
                ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
                ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
            };

            services.AddSingleton(appConfig);

            return appConfig;
        }
    }
}
