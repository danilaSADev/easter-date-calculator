using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var servs = services.ToList();
            services.AddTransient<EasterDateCalculator>();
            //services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, EasterDateCalculator calc)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();

            app.UseMiddleware<EasterDateMiddleware>();
            app.Run(async (context) =>
            {
                int year = int.Parse(context.Request.Query["year"]);
                DateTime date = calc.CalculateEasterDate(year);
                await context.Response.WriteAsync($"<p>Easter in {year} is going to be on {date.ToString("d")} .</p>");
            });

        }
    }
}
