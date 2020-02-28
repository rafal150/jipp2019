using ConverterSDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ConverterWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static List<IConverterPlug> ReadPlugins()
        {
            string assemblyDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDirectory = System.IO.Path.Combine(assemblyDirectory, "plugins");

            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();
            var plugs = assemblies.SelectMany(x => x.GetTypes())
                .Where(x => typeof(IConverterPlug).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => (IConverterPlug)Activator.CreateInstance(x))
                .ToList();
            return plugs;
        }
    }
}
