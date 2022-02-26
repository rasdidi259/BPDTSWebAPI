using BPDTSWebAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
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

    }
}
