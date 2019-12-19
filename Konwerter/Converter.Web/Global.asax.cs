using Autofac;
using Autofac.Integration.Mvc;
using Konwerter;
using Konwerter.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Converter.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Autofac.IContainer container = BuildContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static Autofac.IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<AzureStorageRepository>().As<IStatisticsRepository>();
            }
            else
            {
                containerBuilder.RegisterType<SqlRepository>().As<IStatisticsRepository>();
            }

            containerBuilder.RegisterType<ConvertersService>();

            var assembly = typeof(ConvertersService).Assembly;
            containerBuilder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Conversion")).AsImplementedInterfaces().AsSelf();

            RegisterPlugins(containerBuilder);

            return containerBuilder.Build();
        }

        private static void RegisterPlugins(ContainerBuilder containerBuilder)
        {
            string pluginDirectory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");

            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

            foreach (Assembly assembly in assemblies)
            {
                containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Conversion")).AsImplementedInterfaces().AsSelf();
            }
        }
    }
}
