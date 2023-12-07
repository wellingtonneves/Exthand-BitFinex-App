using AutoMapper;
using Best.Buy.Service.Implementation;
using Best.Buy.Service.Interfaces.Services;
using Best.Buy.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Best.Buy.DTO;
using System.Collections.Generic;
using Best.Buy.DTO.Models;

namespace Best.Buy.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var appConfig = services.ConfigureApi();

            services.AddDbContext<ApplicationDbContext>(
            options =>
                options.UseSqlServer(
                    appConfig.ConnectionString,
                    x => x.MigrationsAssembly("Best.Buy.Repository")),
            ServiceLifetime.Transient);

            services.AddControllers();
            services.AddSwaggerConfiguration();

            services.AddTransient<UnitOfWork>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTO.Models.Product, DTO.ProductResponse>().
                ForMember(
                    dest => dest.Category,
                    opt => opt.MapFrom(src => src.Category.CategoryName)
                ).ReverseMap();

                cfg.CreateMap<PagedList<DTO.Models.Product>, DTO.ProductResponse>().ReverseMap();
                cfg.CreateMap<DTO.Models.Category,DTO.CategoryResponse>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();
            services.AddTransient<IMapper>(c => mapper);

            services.AddDbContext<ApplicationDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Best.Buy.API v1"));

            app.UseCors(builder => builder.AllowAnyMethod()
                                          .AllowAnyOrigin()
            .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
