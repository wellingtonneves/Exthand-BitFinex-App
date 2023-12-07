using Best.Buy.API.Settings;
using Best.Buy.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Best.Buy.API
{
    public static class ServiceRegistration
    {
        //public static void Configurations(this IServiceCollection services)
        //{
        //    var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //    var connectionString = configuration.GetConnectionString("DefaultConnection");

        //    services.AddDbContext<ApplicationDbContext>(
        //    options =>
        //        options.UseSqlServer(
        //            connectionString,
        //            x => x.MigrationsAssembly("Best.Buy.Repository")),
        //    ServiceLifetime.Transient);
        //}

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

        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Best.Buy.API",
                    Contact = new OpenApiContact
                    {
                        Name = "Wellington Neves",
                        Email = "wellingtondn@outlook.com.br",
                        Url = new Uri("https://github.com/wellingtonneves")
                    }
                });
                options.OrderActionsBy(x => x.RelativePath);

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //options.IncludeXmlComments(xmlPath);
            });
        }
    }
}
