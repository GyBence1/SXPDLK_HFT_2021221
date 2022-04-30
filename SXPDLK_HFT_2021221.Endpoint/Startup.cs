using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SXPDLK_HFT_2021221.Data;
using SXPDLK_HFT_2021221.Endpoint.Services;
using SXPDLK_HFT_2021221.Logic;
using SXPDLK_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SXPDLK_HFT_2021221.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IGuitarLogic, GuitarLogic>();
            services.AddTransient<IBrandLogic, BrandLogic>();
            services.AddTransient<IPurchaseLogic, PurchaseLogic>();
            services.AddTransient<IGuitarRepository,GuitarRepository>();
            services.AddTransient<IBrandRepository,BrandRepository>();
            services.AddTransient<IPurchaseRepository,PurchaseRepository>();
            services.AddTransient<GuitarDbContext,GuitarDbContext>();
            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });

        }
    }
}
