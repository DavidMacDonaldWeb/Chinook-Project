using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.IO;
using Microsoft.EntityFrameworkCore;
using UWS.Shared;

namespace UWS.Shared
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            string databasePath = Path.Combine("..", "Chinook.db");

            services.AddDbContext<Chinook>(options => options.UseSqlite($"Data Source = {databasePath}; Foreign Keys = False"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else 
            {
                app.UseHsts();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
               // endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("");
               // });
               endpoints.MapRazorPages();
            });
        }
    }
}
//David MacDonald
