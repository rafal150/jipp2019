using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPFKonwerter.Services;
using UnitConverter.Logic;
using Autofac;

namespace UnitsConverter.Web.Controllers
{
    public class HomeController : Controller
    {
        KonwerterService srv;
        ILifetimeScope scp;
        public HomeController(ILifetimeScope scope,KonwerterService service)
        {
            scp = scope;
            srv = service;
        }
        
        public ActionResult Index()
        {
            
            return View(srv.GetConverters());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Convert(string unitFrom, string unitTo, string valueFrom,
            string converterType)
        {
            //czemu null
            //var t=(Type.GetType(converterType) as ConverterSDK.IConvertible); 
            ConverterSDK.IConvertible cnv=scp.Resolve(Type.GetType(converterType)) as ConverterSDK.IConvertible;
            string res=cnv.Convert(cnv.Units.IndexOf(unitFrom), cnv.Units.IndexOf(unitTo), Double.Parse(valueFrom));
            return res;
        }
    }
}