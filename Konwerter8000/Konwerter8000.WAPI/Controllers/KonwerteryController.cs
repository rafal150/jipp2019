using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using System.Web.Http;
using Konwerter8000.Konwersje;
using System.Net;

namespace Konwerter8000.WAPI.Controllers
{
    public class KonwerteryController : ApiController
    {
        Konwerter8000Konwersja Konwerter8000;
        ILifetimeScope LifetimeScope;
        
        public KonwerteryController(ILifetimeScope scope, Konwerter8000Konwersja konwerter)
        {
            Konwerter8000 = konwerter;
            LifetimeScope = scope;
        }
        [Route("api/konwertery")]
        [HttpGet]
        public List<IKonwerter8000> GetKonwerter8000()
        {
            try
            {
                List<IKonwerter8000> konwerters = Konwerter8000.PobierzKonwertery();
                return konwerters;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
        [Route("api/konwertery/convert")]
        [HttpGet]

        public double GetConversion(string fromUnit, string toUnit, double value, string konwerterType)
        {
            try
            { 
                IKonwerter8000 konwerter = Konwerter8000.PobierzKonwertery()
                            .FirstOrDefault(k => k.NazwaKategorii == konwerterType);
                double konw = konwerter.Konwertuj(fromUnit, toUnit, value);
                return konw;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}