using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Konwerter5.WebAPI
{
    public class Bootstrapper
    {
        public static void Run()
        {
            WebApiConfig.Initialize(GlobalConfiguration.Configuration);

        }
    }
}