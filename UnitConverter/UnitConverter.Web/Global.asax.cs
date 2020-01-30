using Autofac;
using Autofac.Integration.Mvc;
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

namespace UnitConverter.Web {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            Autofac.IContainer container = BuildContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        private static Autofac.IContainer BuildContainer() {
            var containerBuilder = new ContainerBuilder();

            // register all controllers (UnitConverter.Web/Controllers/*.cs)
            containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);

            // set statistics repository class using app config
            string statisticsRepositoryConfig = ConfigurationManager.AppSettings["StatisticsRepository"].ToLower();
            if (statisticsRepositoryConfig == "sql") {
                containerBuilder.RegisterType<StatisticsSqlRepository>().As<IStatisticsRepository>();
            } else if (statisticsRepositoryConfig == "azurestorage") {
                containerBuilder.RegisterType<StatisticsAzureStorageRepository>().As<IStatisticsRepository>();
            } else {
                throw new Exception("B³êdna konfiguracja StatisticsRepository");
            }

            containerBuilder.RegisterType<Converters.Converters>();

            // register all converters in this project (UnitConverter.web/Converters/*.cs)
            // edit: register all converters in all projects including UnitConverter.Logic (UnitConverter.Logic/Converters/*cs)
            RegisterConverters(containerBuilder);

            // register all converters in plugins folder (UnitConverter.web/bin/Debug/plugins/*.dll)
            RegisterPlugins(containerBuilder);

            return containerBuilder.Build();
        }
        private static void RegisterConverters(ContainerBuilder containerBuilder) {
            var assembly = typeof(Converters.Converters).Assembly; // Assembly.GetExecutingAssembly();
            // register all classes...
            containerBuilder.RegisterAssemblyTypes(assembly)
                // ... that implement Converters.IConverter
                .Where(t => typeof(Converters.IConverter).IsAssignableFrom(t))
                .AsImplementedInterfaces().AsSelf();
        }
        private static void RegisterPlugins(ContainerBuilder containerBuilder) {
            // plugins directory
            string pluginDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "plugins");
            // .dll's list
            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

            foreach (Assembly assembly in assemblies) {
                containerBuilder.RegisterAssemblyTypes(assembly)
                    .Where(t => typeof(Converters.IConverter).IsAssignableFrom(t))
                    .AsImplementedInterfaces();
            }
        }
    }
}
