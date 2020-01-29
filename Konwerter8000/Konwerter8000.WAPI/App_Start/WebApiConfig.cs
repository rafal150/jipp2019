using System;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Autofac;
using System.Reflection;
using System.Configuration;
using System.IO;
using Autofac.Integration.WebApi;
using Konwerter8000.Konwersje;

namespace Konwerter8000.WAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Konfiguracja i usługi składnika Web API

            // Trasy składnika Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var json = config.Formatters.JsonFormatter;


            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;


        }


        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }
        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
        static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); 
            builder.RegisterType<Konwerter8000Konwersja>(); 

            InitializeKonwertery(builder);  

            InitializeStatisticsRepo(builder);  

            InitializeKonwerterPlugins(builder); 

            Container = builder.Build();
            return Container;
        }

        static void InitializeKonwertery(ContainerBuilder builder)
        {
            var assembly = typeof(Konwerter8000Konwersja).Assembly;
            builder.RegisterAssemblyTypes(assembly)
                .Where
                (
                    t => t.Name.StartsWith("Konwerter8000", StringComparison.Ordinal)
                ).AsImplementedInterfaces().AsSelf();
        }

        static void InitializeKonwerterPlugins(ContainerBuilder builder)
        {
            string pluginDirectory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin\\dll");
            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();
            foreach (Assembly assembly in assemblies)
            {
                builder.RegisterAssemblyTypes(assembly).Where
                    (
                        t => t.Name.StartsWith("Konwerter8000", StringComparison.Ordinal)
                    ).AsImplementedInterfaces().AsSelf();
            }
        }

        static void InitializeStatisticsRepo(ContainerBuilder builder)
        {
            if (ConfigurationManager.AppSettings["Log"] == "AzureStorage")
            {
                builder.RegisterType<LogDoAzure>()
                        .As<ILog>()
                        .AsSelf();
            }
            else
            {
                builder.RegisterType<LogDoSQL>()
                        .As<ILog>()
                        .AsSelf();
            }
        }

    }
}
