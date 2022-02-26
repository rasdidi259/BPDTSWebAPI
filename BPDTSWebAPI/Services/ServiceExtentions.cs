using AspNetCoreRateLimit;
using BPDTSWebAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPDTSWebAPI.Services
{
    public static class ServiceExtentions
    {

        /// <summary>
        /// Handling Exceptions Globally using IApplicationBuilder Middleware
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Log.Error($"Something went wrong in the {contextFeature.Error}");

                        await context.Response.WriteAsync(new Error
                        {
                            StatusCode = context.Response.StatusCode,
                            Messasge = "Internal Server Error. Please try again later."
                        }.ToString());
                    }
                });
            });
        }

        /// <summary>
        /// For Limiting the Rate of Access of the Web API
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRateLimiting(this IServiceCollection services)
        {
            //var rateLimitRules = new List<RateLimitRule>
            //{
            //    new RateLimitRule
            //    {
            //        Endpoint="*",
            //        Limit= 5,
            //        Period="10m"
            //    }
            //};

            //services.Configure<IpRateLimitOptions>(opt =>
            //{
            //    opt.GeneralRules = rateLimitRules;
            //});

            //services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            //services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            //services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            var rateLimitRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint="*",   // every endpoint
                    Limit=5,        // limited to one call
                    Period="10m"     // per 10 minute (Use 5s for 5seconds for testing - Error Message ---- API calls quota exceeded! maximum admitted 1 per 5s.)
                }
            };

            services.Configure<IpRateLimitOptions>(opt =>
            {
                opt.GeneralRules = rateLimitRules;
            });

            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
        }

    }
}
