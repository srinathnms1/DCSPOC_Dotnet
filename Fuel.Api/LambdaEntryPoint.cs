namespace Fuel.Api
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Serilog;
    using System;
    using System.IO;

    public class LambdaEntryPoint : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        protected override void Init(IWebHostBuilder builder)
        {
            builder
             .ConfigureAppConfiguration(config =>
            {
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                config.AddJsonFile($"appsettings.{environment}.json", optional: true);
                config.AddEnvironmentVariables();
            })
            .UseStartup<Startup>()
            .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration.Enrich.FromLogContext()
                .ReadFrom.Configuration(hostingContext.Configuration))
            .UseLambdaServer();
        }
    }
}
