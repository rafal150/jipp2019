using Autofac;
using Autofac.Integration.Mvc;
using Konwerter_Azure;
using Konwerter_Azure.Services;
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

namespace KonwerterJednostek.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IContainer container = BuildContainer(); // dodane
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); // twórz w tym kontenerze

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        private static IContainer BuildContainer()
        {
            var myContainerBuilder = new ContainerBuilder();

            myContainerBuilder.RegisterControllers(typeof(MvcApplication).Assembly); //autofac mvc

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                myContainerBuilder.RegisterType<StatisticsAzureStorageRepository>().As<IStatisticsRepository>();
            }
            else
            {
                myContainerBuilder.RegisterType<StatisticsSqlRepository>().As<IStatisticsRepository>();
            }

            myContainerBuilder.RegisterType<ConvertersService>();

            //var assembly = Assembly.GetExecutingAssembly(); to po staremu przed wyniesieniem logiki do oddzielnej dll
            var assembly = typeof(ConvertersService).Assembly;
            myContainerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Konwerter")).AsImplementedInterfaces().AsSelf();//rejestracja

            RejestrowaniePluginow(myContainerBuilder);

            return myContainerBuilder.Build();
        }

        private static void RejestrowaniePluginow(ContainerBuilder containerBuilder)
        {
            //string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);// sciezka do exe
            //string pluginDirectory = Path.Combine(assemblyDirectory, "plugins");// dodaje podfolder plugins

            string pluginDirectory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory,"bin"); // sciezka do pluginow dla web

            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList(); // szukaj plikowkonczoncych sie na Plugin.dll D:\WWSI_5\Jezyki_i_paradygmaty_programowania_lab\Konwerter_Azure\Konwerter_Azure\bin\Debug\plugins

            foreach (Assembly assembly in assemblies)// na kazdym pliku wywoluje load from- to pobiera te biblioteki
            {
                containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Konwerter")).AsImplementedInterfaces().AsSelf();
            }
        }
    }
}
