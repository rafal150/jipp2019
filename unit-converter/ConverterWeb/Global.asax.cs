using Autofac;
using Autofac.Integration.Mvc;
using converter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ConverterWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IContainer container = BuildContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();            
            containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);            
            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<TelemetryAzureRepository>().As<ITelemetryRepository>();
            }
            else
            {
                containerBuilder.RegisterType<TelemetrySqlRepository>().As<ITelemetryRepository>();
            }            
            containerBuilder.RegisterType<ConvertersService>();            
            var assembly = typeof(ConvertersService).Assembly; // Assembly.GetExecutingAssembly();
            containerBuilder.RegisterAssemblyTypes(assembly)                .Where(t => t.Name.EndsWith("Converter")).AsImplementedInterfaces().AsSelf();            
            RegisterPlugins(containerBuilder);

            return containerBuilder.Build();
        }

        private void RegisterPlugins(ContainerBuilder containerBuilder)
        {
            string pluginDirectory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");            
            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();            
            foreach (Assembly assembly in assemblies)
            {
                containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Converter")).AsImplementedInterfaces().AsSelf();
            }
        }
    }
}
