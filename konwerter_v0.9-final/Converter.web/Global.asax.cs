using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using konwerter;
using konwerter.services;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Converter.web
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

            if (ConfigurationManager.AppSettings["StatisticsRepositorySwitch"] == "AzureStorage")
            {
                containerBuilder.RegisterType<UsageStatisticsAzureRepo>().As<IUsageStatisticsRepo>();
            }
            else
            {
                containerBuilder.RegisterType<UsageStatisticsSqlRepo>().As<IUsageStatisticsRepo>();
            }

            //containerBuilder.RegisterType<ConverterWindow>();
            containerBuilder.RegisterType<ConvertersService>();

            //var assembly = Assembly.GetExecutingAssembly();
            var assembly = typeof(ConvertersService).Assembly;
            containerBuilder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Converter")).AsImplementedInterfaces().AsSelf();

            RegisterPlugins(containerBuilder);


            return containerBuilder.Build();
        }

        private static void RegisterPlugins(ContainerBuilder containerBuilder)
        {
            //string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //string pluginDirectory = Path.Combine(assemblyDirectory, "plugins");

            string pluginDirectory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");

            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

            foreach (Assembly assembly in assemblies)
            {
                containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Converter")).AsImplementedInterfaces().AsSelf();
            }
        }
    }
}
