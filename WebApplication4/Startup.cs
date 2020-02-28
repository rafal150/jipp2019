using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ConverterLogic;
using ConverterSDK;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace WebApplication4
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
            //if (ConfigurationManager.AppSettings["StatisticsRepository"] == "azure")
            //{
            //    services.AddSingleton<IRepository<StatisticsEntryDto>, AzureStatisticsRepository>();
            //}
            //else
            //{
            //    services.AddSingleton<IRepository<StatisticsEntryDto>, SqlStatisticsRepository>();
            //}

            services.AddSingleton<IRepository<StatisticsEntryDto>, NoopRepository>();
            services.AddSingleton<IConverter, Converter>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseStaticFiles();

            RegisterPlugins(app);
        }

        private void RegisterPlugins(IApplicationBuilder app)
        {
            List<IConverterPlug> plugins = ReadPlugins();
            IConverter converter = app.ApplicationServices.GetService<IConverter>();
            plugins.ForEach(x => converter.AddConvertion(x.GetFrom(), x.GetTo(), x.GetConversionFunc()));
        }

        private static List<IConverterPlug> ReadPlugins()
        {
            string assemblyDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDirectory = System.IO.Path.Combine(assemblyDirectory, "plugins");

            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();
            var plugs = assemblies.SelectMany(x => x.GetTypes())
                .Where(x => typeof(IConverterPlug).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => (IConverterPlug)Activator.CreateInstance(x))
                .ToList();
            return plugs;
        }
    }
}
