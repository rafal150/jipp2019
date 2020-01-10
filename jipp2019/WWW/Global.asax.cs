using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Logic;
using Logic.Commons;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WWW.App_Start;

namespace WWW
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected voId Application_Start()
        {
            IContainer container = BuildContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApIdependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);
            containerBuilder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                //containerBuilder.RegisterType<AzureDbController>().As<IStatisticsRepository>();
            }
            else
            {
                //containerBuilder.RegisterType<StatisticsSqlRepository>().As<IStatisticsRepository>();
            }

            containerBuilder.RegisterType<ConverterService>();

            var assembly = typeof(ConverterService).Assembly;
            containerBuilder.RegisterAssemblyTypes(assembly)
               .Where(t => t.Name.EndsWith("")).AsImplementedInterfaces();

            //RegisterPlugins(containerBuilder);

            return containerBuilder.Build();
        }

        private static voId RegisterPlugins(ContainerBuilder containerBuilder)
        {
            string pluginDirectory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");
            var assemblies = Directory.GetFiles(pluginDirectory, "*.dll").Select(Assembly.LoadFrom).ToList();

            foreach (Assembly assembly in assemblies)
            {
                containerBuilder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
            }
        }
    }
}
