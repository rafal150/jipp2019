using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Konwerter5.Uslugi;
using Autofac;

namespace Konwerter5.WebAPI.Controllers
{
    public class KonwerteryController : ApiController
    {
        Konwerter5Usluga Konwerter;
        ILifetimeScope LifetimeScope;

        public KonwerteryController(ILifetimeScope scope, Konwerter5Usluga konwerter)
        {
            Konwerter = konwerter;
            LifetimeScope = scope;
        }
        [Route("api/konwertery")]
        [HttpGet]

        public List<IKonwerter5> GetKonwerters()
        {
            try
            { 
                    List<IKonwerter5> konwerters = Konwerter.PobierzKonwertery();

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
                IKonwerter5 konwerter5 = Konwerter.PobierzKonwertery()
                        .Where(k => k.NazwaKategorii == konwerterType)
                        .FirstOrDefault();

                double _value = konwerter5.Konwertuj(fromUnit, toUnit, value);

                return _value;
            }
            catch
            {

                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

    }
}
