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
using Unitconverter;

namespace UnitConverter.Web
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

            if (ConfigurationManager.AppSettings["StatRepo"] == "Azure")
            {
                containerBuilder.RegisterType<StatisticsAzureRepo>().As<IStatisticsRepository>();
            }
            else
            {
                containerBuilder.RegisterType<StatisticsSQLRepo>().As<IStatisticsRepository>();
            }

            containerBuilder.RegisterType<Unitconverter.Services.ConvServices>();

            var assembly = typeof(Unitconverter.Services.ConvServices).Assembly; //System.Reflection.Assembly.GetExecutingAssembly();
            containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Konwerter")).AsImplementedInterfaces().AsSelf();

           // RegisterPlugin(containerBuilder);
            return containerBuilder.Build();

        }

        private static void RegisterPlugin(ContainerBuilder containerbuilder)
        {

            //string assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDir = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");
            var assemblies = Directory.GetFiles(pluginDir, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

            foreach (Assembly assembly in assemblies)
            {
                containerbuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Konwerter")).AsImplementedInterfaces();
            }
        }
    
    }
}
