using JIPP5_LAB.DataProviders;
using JIPP5_LAB.Interfaces;
using JIPP5_LAB.SDK;
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
using Unity;
using Unity.AspNet.Mvc;

namespace JIPP5_LAB.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var conteiner = BuildContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(conteiner));


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private IUnityContainer BuildContainer()
        {
            var container = new UnityContainer();

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                container.RegisterType(typeof(IDataHelper), typeof(AzureHelper));
            }
            else
            {
                container.RegisterType(typeof(IDataHelper), typeof(DatabaseHelper));
            }
            var assembly = typeof(IDataHelper).Assembly;
            var viewsAssembly = Assembly.GetExecutingAssembly();
            RegisterConverters(assembly, container);

            RegisterPlugins(container);
            return container;
        }

        private void RegisterPlugins(IUnityContainer container)
        {
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDirectory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");

            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();
            foreach (var assembly in assemblies)
            {
                RegisterConverters(assembly, container);
            }
        }

        private void RegisterConverters(Assembly assembly, IUnityContainer container)
        {
            var listOfConverters = assembly.GetTypes().Where(x => x.Name.EndsWith("ConverterHelper") && x.IsClass).ToList();

            foreach (var item in listOfConverters)
            {
                container.RegisterType(typeof(IConverterHelper), item, item.Name);
            }
        }
    }
}
