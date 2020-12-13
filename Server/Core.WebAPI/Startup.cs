using AutoMapper;
using Core.Shared.Helpers;
using Core.WebAPI.Extensions;
using Core.WebAPI.Sockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Core.WebAPI
{
    public class Startup
    {
        // ======================================= //
        public IConfiguration config { get; }
        // ======================================= //
        public Startup(IConfiguration config, IWebHostEnvironment env) => this.config = config;
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ======================================= //
            // IServiceCollection custom extensions
            // ======================================= //
            services
                .SetDependencies()
                .SetEntityFramework(config)
                .SetAuthentication(config)
                .SetControllers();
            // ======================================= //
            // IServiceCollection default injectors
            // ======================================= //
            services
                .AddCors()
                .AddAutoMapper(typeof(MappingProfiles).Assembly)
                .AddSignalR(); /* TODO: Hopefuly implement realtime context updates for browser caching */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder builder, IWebHostEnvironment env)
        {
            // ======================================= //
            // Configuring Env-Based Cross-Origin Access
            // ======================================= //
            if (env.IsDevelopment())
            {
                builder
                    .UseDeveloperExceptionPage()
                    .UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            }
            else builder
                .UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("/* TODO: Insert host provider root domain */"));

            // ======================================= //
            // IApplicationBuilder runtime settings
            // ======================================= //
            builder.UseRouting();
            builder.UseAuthentication();
            builder.UseAuthorization();
            builder.UseEndpoints(endpoints =>
            {
                /* TODO: Map SignalR Hubs () => endpoints.MapHub<T>("_name_") */
                endpoints.MapControllers();
                endpoints.MapHub<ConsoleHub>("hub/console");
                endpoints.MapHub<ContextHub>("hub/context");
            });
        }
    }
}