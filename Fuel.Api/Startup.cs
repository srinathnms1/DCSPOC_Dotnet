namespace Fuel.Api
{
    using DcsService.Core;
    using Fuel.Api.Infrastructure.Filters;
    using Fuel.Api.Helpers.Binders;
    using Fuel.Api.Infrastructure.Services;
    using Fuel.Domain;
    using Fuel.Infrastructure;
    using Fuel.Infrastructure.Repositories;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using Fuel.Api.Helpers;
    using AutoMapper;
    using Fuel.Domain.ViewModel;
    using Fuel.Api.Infrastructure.HttpErrors;
    using System.Net;
    using System.Threading.Tasks;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers(options => options.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider()))
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("*");
                    });
            });
            services.AddMvcCore(config => config.Filters.Add(typeof(ValidModelStateFilter)));
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<PostgresContext>((serviceProvider, options) => options
                .UseNpgsql(Helper.GetConnectionString(), builder => builder.MigrationsAssembly(typeof(Startup).Assembly.FullName))
                .UseInternalServiceProvider(serviceProvider));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IFuelInfoRepository), typeof(FuelInfoRepository));
            services.AddScoped(typeof(ILocationRepository), typeof(LocationRepository));
            services.AddScoped(typeof(IVehicleRealTimeInfoRepository), typeof(VehicleRealTimeInfoRepository));
            services.AddScoped(typeof(IFuelService), typeof(FuelService));
            services.AddScoped(typeof(ILocationService), typeof(LocationService));
            services.AddAutoMapper(typeof(LocationViewModel));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DCS Service", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(context =>
                {
                    var userMessage = new[] { context.Response.Body.ToString() };
                    return Task.FromResult(HttpError.Create(env, (HttpStatusCode)context.Response.StatusCode, context.Response.StatusCode.ToString(), userMessage, "Unhandled Error"));
                });
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DCS Service");
            });
        }
    }
}
