using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Configuration;
using SEM5WPF_1;
using SEM5WPF_1.Services;
using System.Web.Optimization;
using System.Web.Routing;

namespace Konwerter.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IContainer container = BulidContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static IContainer BulidContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<StatystykiAzureRepozytorium>().As<IStatystykiRepozytorium>();
            }
            else
            {
                containerBuilder.RegisterType<StatystykiSqlRepozytorium>().As<IStatystykiRepozytorium>();
            }

            containerBuilder.RegisterType<KonwerterServices>();

            var assembly = typeof(KonwerterServices).Assembly;
            containerBuilder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Konwerter")).AsImplementedInterfaces().AsSelf();

            RegisterPlugins(containerBuilder);

            return containerBuilder.Build();
        }

        private static void RegisterPlugins(ContainerBuilder containerBuilder)
        {
            //string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDirectory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");

            var assmbiles = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

            foreach (Assembly assembly in assmbiles)
            {
                containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Plugin")).AsImplementedInterfaces();
            }
        }
    }
}
