using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GroceriesApi.Models;
using Microsoft.Extensions.Options;
using GroceriesApi.Services;
using NuGet.Frameworks;

namespace GroceriesApi
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
            // requires using Microsoft.Extensions.Options
            services.Configure<GroceryDatabaseSettings>(
                Configuration.GetSection(nameof(GroceryDatabaseSettings)));

            services.AddSingleton<IGroceryDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<GroceryDatabaseSettings>>().Value);

            services.AddSingleton<GroceryListService>();

            services.AddSingleton<GroceryDueDateService>();

            services.AddSingleton<GroceryPurchasedService>();

            services.AddSingleton<GroceryStoreService>();

            services.AddControllers();

            services.AddSwaggerGen( gen =>
            {
                gen.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Grocery Manager API", Version = "V1.0" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(ui => {
                ui.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Grocery Manager API Endpoint");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
