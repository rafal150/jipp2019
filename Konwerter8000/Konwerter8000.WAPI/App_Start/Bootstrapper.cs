
using System.Web.Http;

namespace Konwerter8000.WAPI
{
    public static class  Bootstrapper
    {
        public static void Run()
        {
            WebApiConfig.Initialize(GlobalConfiguration.Configuration);

        }
    }
}