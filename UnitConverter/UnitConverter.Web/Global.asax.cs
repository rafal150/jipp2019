using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace UnitConversion.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IContainer container = BuildContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

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
            if (ConfigurationManager.AppSettings["ServiceRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<AzureServiceRepository>().As<IServiceRepository>();
            }
            else 
            //if (ConfigurationManager.AppSettings["ServiceRepository"] == "SQL")
            {
                containerBuilder.RegisterType<SqlServiceRepository>().As<IServiceRepository>();
            }

            containerBuilder.RegisterType<ConverterService>();

            var assembly = typeof(ConverterService).Assembly;
            containerBuilder.RegisterAssemblyTypes(assembly).Where(x => typeof(UnitConverter).IsAssignableFrom(x) && x.CustomAttributes.Count() > 0 && x.GetCustomAttribute<ConverterClassTypeAttribute>().ClassType == ClassType.Constant).As<UnitConverter>();

            RegisterPlugins(containerBuilder);

            return containerBuilder.Build();
        }

        private static void RegisterPlugins(ContainerBuilder container)
        {
            string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
            string pluginDirectory = Path.Combine(directory, "plugins");
            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

            foreach (Assembly assembly in assemblies)
            {
                container.RegisterAssemblyTypes(assembly).Where(x => typeof(UnitConverter).IsAssignableFrom(x)).As<UnitConverter>();
            }
        }
    }
}
