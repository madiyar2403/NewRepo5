using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace VirtualCashMachine
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=VirtualCashMachine}/{action=Add}/{id?}");
            });
            app.Map("/index", Index);
            app.Map("/add", Add);
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync($"VirtualCashMachine");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page Not Found");
            });

        }
        private static void Index(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Index");
            });
        }
        private static void Add(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Add");
            });
        }

        public delegate Task RequestDelegate(HttpContext context);
    }
}
