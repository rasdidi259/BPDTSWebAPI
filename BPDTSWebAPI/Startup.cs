using AspNetCoreRateLimit;
using BPDTSWebAPI.Configurations;
using BPDTSWebAPI.Repository;
using BPDTSWebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPDTSWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();


            // Keep track of who requested what and how many times
            services.AddMemoryCache();

            services.ConfigureRateLimiting();

            services.AddHttpContextAccessor();

            services.ConfigureHttpCacheHeaders();

            // Added CORS Policy
            services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicyAllowAll", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );
            });

            // Added AutoMapper(MapperInitializer)
            services.AddAutoMapper(typeof(MapperInitializer));

            // Register IUnitOfWork / UnitOfWork
            services.AddTransient<IUsersRepository, UsersRepository>();

            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BPDTSWebAPI", Version = "v1" });
            });

            //services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BPDTSWebAPI v1"));
            }

            app.ConfigureExceptionHandler(); // Errors Handling Globally

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicyAllowAll"); // Added CORS policy CorsPolicyAllowAll

            // Response Caching Middleware
            app.UseResponseCaching();

            app.UseHttpCacheHeaders();

            app.UseIpRateLimiting();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
