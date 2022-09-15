using Exthand.Bitfinex.App.Action;
using Exthand.Bitfinex.Service;
using Exthand.Bitfinex.Shared.Helpers.Extensions;
using Exthand.Bitfinex.Shared.Interfaces.Action;
using Exthand.Bitfinex.Shared.Interfaces.Repositories;
using Exthand.Bitfinex.Shared.Interfaces.Services;
using Exthand.BitFinex.Repository;
using Hangfire;
using Hangfire.Console;
using Hangfire.Console.Extensions;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Exthand.Bitfinex.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire((serviceProvider, configuration) => configuration
                .UseConsole()
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMemoryStorage());

            services.AddHangfireConsoleExtensions();

            var appConfig = services.ConfigureApi();

            services.AddHangfireServer(
                options => 
                    { 
                        options.SchedulePollingInterval = TimeSpan.FromSeconds(appConfig.SCHEDULE_INTERVAL);
                    });

            services.AddTransient<IExthandJob, ExthandJob>();
            services.AddTransient<IBitFinexService, BitFinexService>();
            services.AddTransient<IBitFinexRepository, BitFinexRepository>();
        }

        public void Configure(IApplicationBuilder app, IRecurringJobManager recurringJobManager, IServiceProvider serviceProvider)
        {
            app.UseRouting();

            app.UseHangfireDashboard();

            recurringJobManager.AddOrUpdate("View Trades", () => serviceProvider.GetService<IExthandJob>().RunAsync(), "*/10 * * * * *");
        }
    }
}
