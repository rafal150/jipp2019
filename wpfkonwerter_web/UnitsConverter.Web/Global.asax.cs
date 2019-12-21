using Autofac;
using Autofac.Integration.Mvc;
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
using WPFKonwerter.Model;
using WPFKonwerter.Model.DTO;

namespace UnitsConverter.Web
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
        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);

            if (ConfigurationManager.AppSettings["StatisticsRepositorySource"] == "Azure")
                containerBuilder.RegisterType<Statistics2Azure>().As<IStatisticsRepo>();
            else
                containerBuilder.RegisterType<Statistic2SQL>().As<IStatisticsRepo>();


            containerBuilder.RegisterType<WPFKonwerter.Services.KonwerterService>();

            var assembly = Assembly.GetExecutingAssembly();
            containerBuilder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Converter")).AsImplementedInterfaces().AsSelf();

            RegisterPlugins(containerBuilder);
            return containerBuilder.Build();
        }
        private static void RegisterPlugins(ContainerBuilder containerBuilder)
        {
            //string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //string pluginDir = Path.Combine(dir, "plugins");

            string pluginDir = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");


            var assemblies = Directory.GetFiles(pluginDir, "*Plugin.dll")
                                      .Select(Assembly.LoadFrom)
                                      .ToList();

            foreach (Assembly assmb in assemblies)
                containerBuilder.RegisterAssemblyTypes(assmb)
                    .Where(x => x.Name.EndsWith("Converter")).AsImplementedInterfaces().AsSelf();
        }
    }
}
