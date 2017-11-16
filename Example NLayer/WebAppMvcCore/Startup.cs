using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nlayer.Samples.NLayerApp.Application.Main.ERPModule.Services;
using Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.CountryAgg;
using Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.CustomerAgg;
using Nlayer.Samples.NLayerApp.Infrastructure.Data.Main.ERPModule.Repositories;
using Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Adapter;
using Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.NetFramework.Adapter;

namespace WebAppMvcCore
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
            services.AddMvc();

            services.AddTransient<ICustomerAppService, CustomerAppService>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            //-> Adapters
            //services.AddTransient<ITypeAdapterFactory, AutomapperTypeAdapterFactory>();
            //var sp = services.BuildServiceProvider();
            //var typeAdapterFactory = sp.GetService<ITypeAdapterFactory>();
            //TypeAdapterFactory.SetCurrent(typeAdapterFactory);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
