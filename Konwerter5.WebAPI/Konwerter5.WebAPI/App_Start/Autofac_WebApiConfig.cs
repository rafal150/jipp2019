using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using System.Reflection;
using Konwerter5.Uslugi;
using Konwerter5;
using System.Configuration;
using System.IO;
using Autofac.Integration.WebApi;

namespace Konwerter5.WebAPI
{
    /// <summary>
    /// Autofac IoC configuration
    /// </summary>
    public static partial class WebApiConfig
    {
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
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //rejestruj kontrolery WebApi
            builder.RegisterType<Konwerter5Usluga>(); //rejestruj konwertery (T)

            InitializeKonwertery(builder);  //Dodaj rejestrowanie konwerterow

            InitializeStatisticsRepo(builder);  // Dodaj rejestrowanie repozytoriow statustyk uzycia (T)

            InitializeKonwerterPlugins(builder); // Dodaj resjestrowanie pluginow konwertera

            Container = builder.Build();
            return Container;
        }

        static void InitializeKonwertery(ContainerBuilder builder)
        {
            var assembly = typeof(Konwerter5Usluga).Assembly;
            builder.RegisterAssemblyTypes(assembly)
                .Where
                (
                    t => t.Name.StartsWith("Konwerter5", StringComparison.Ordinal)
                ).AsImplementedInterfaces().AsSelf();
        }

        static void InitializeKonwerterPlugins(ContainerBuilder builder)
        {
            string pluginDirectory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin\\DLL\\Plugins");
            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();
            foreach (Assembly assembly in assemblies)
            {
                builder.RegisterAssemblyTypes(assembly).Where
                    (
                        t => t.Name.StartsWith("Konwerter5", StringComparison.Ordinal)
                    ).AsImplementedInterfaces().AsSelf();
            }
        }

        static void InitializeStatisticsRepo(ContainerBuilder builder)
        {
            if (ConfigurationManager.AppSettings["RepozytoriumStatystyk"] == "AzureStorage")
            {
                builder.RegisterType<StatystykiUzyciaRepozytoriumAzureStorageTable>()
                        .As<IRepozytoriumStatystykUzycia>()
                        .AsSelf();
            }
            else
            {
                builder.RegisterType<StatystykiUzyciaRepozytoriumSQL>()
                        .As<IRepozytoriumStatystykUzycia>()
                        .AsSelf();
            }
        }

    }
}