using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Labs.Converters;
using Labs.Databases;
using Autofac;
using System.Configuration;
using System.IO;
using System.Reflection;
using Autofac.Integration.Mvc;
using System.Web.Http;
using Autofac.Integration.WebApi;


namespace Labs.Web
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
        private static void SearchPlugin(ContainerBuilder containerBuilder)
        {
            //string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginsDir = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");
            var plugins = Directory.GetFiles(pluginsDir, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

            foreach (Assembly assembly in plugins)
            {
                containerBuilder.RegisterAssemblyTypes(assembly).Where(conv => conv.Name.EndsWith("Conv")).AsImplementedInterfaces().AsSelf();
            }
        }

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);
            containerBuilder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<AzureRepo>().As<InterfaceRepository>();
            }
            else
            {
                containerBuilder.RegisterType<SQLRepo>().As<InterfaceRepository>();
            }

            //containerBuilder.RegisterType<MainWindow>(); - not needed in web app
            containerBuilder.RegisterType<SConverters>();

            var searchConv = typeof(SConverters).Assembly; //Assembly.GetExecutingAssembly(); <--- old 
            containerBuilder.RegisterAssemblyTypes(searchConv).Where(conv => conv.Name.EndsWith("Conv")).AsImplementedInterfaces().AsSelf();

            SearchPlugin(containerBuilder);

            return containerBuilder.Build();
        }
    }

}
