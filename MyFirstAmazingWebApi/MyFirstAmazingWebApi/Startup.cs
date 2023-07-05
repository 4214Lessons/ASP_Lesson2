using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyFirstAmazingWebApi.Extensions;
using MyFirstAmazingWebApi.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAmazingWebApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyFirstAmazingWebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyFirstAmazingWebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Middleware Use Started");
            //    await next.Invoke();
            //    Console.WriteLine("Middleware Use Ended");
            //});

            //app.Run(async context => Console.WriteLine("Middleware Run"));

            //app.Map("/home", builder =>
            //{
            //    builder.Use(async (context, next) =>
            //    {
            //        Console.WriteLine("Middleware Map Started");
            //        await next.Invoke();
            //        Console.WriteLine("Middleware Map Ended");
            //    });
            //});

            //app.UseHakuna();
            app.UseMiddleware<HakunaMiddleware>();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
