namespace Fuel.Api
{
    using System;
    using System.Threading.Tasks;

    using Amazon.Lambda.Core;
    using Amazon.Lambda.APIGatewayEvents;
    using Amazon.Lambda.RuntimeSupport;
    using Amazon.Lambda.Serialization.Json;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using System.IO;
    using Serilog;

    public class Program
    {
        public static void Main(string[] args)
        {
            #region Setup for development
            CreateHostBuilder(args).Build().Run(); 
            #endregion
            #region Setup for deployment
            //Log.Information($"App started at {DateTime.Now}");
            //var lambdaEntry = new LambdaEntryPoint();
            //var functionHandler = (Func<APIGatewayProxyRequest, ILambdaContext, Task<APIGatewayProxyResponse>>)(lambdaEntry.FunctionHandlerAsync);
            //using (var handlerWrapper = HandlerWrapper.GetHandlerWrapper(functionHandler, new JsonSerializer()))
            //using (var bootstrap = new LambdaBootstrap(handlerWrapper))
            //{
            //    bootstrap.RunAsync().Wait();
            //} 
            #endregion
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration(config =>
                 {
                     var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                     config.SetBasePath(Directory.GetCurrentDirectory());
                     config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                     config.AddJsonFile($"appsettings.{environment}.json", optional: true);
                     config.AddEnvironmentVariables();
                 })
                .UseStartup<Startup>();
                //.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration.Enrich.FromLogContext()
                //    .ReadFrom.Configuration(hostingContext.Configuration));
    }
}
