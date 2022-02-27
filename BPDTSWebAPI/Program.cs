using BPDTSWebAPI.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPDTSWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                path: "c:\\bpdtwebapi\\logs\\log-.txt",  // logfile with filename
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {UserId} {Event} - {Message}{NewLine}{Exception}", // logfile with timestamp
                rollingInterval: RollingInterval.Day, // logfile with segments
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information // logfile with informaation
            ).CreateLogger();


            try
            {
                // Initialize Client
                RestApiService.InitializeClient();

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, "Application Failed to start.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog() // logger for logging application errors
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
