using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using SEM5WPF_1.Services;

namespace Konwerter.WEB.Controllers
{
    public class KonwerterController : ApiController
    {
        private KonwerterServices konwerterservices;
        private ILifetimeScope scope;
        public KonwerterController(ILifetimeScope scope, KonwerterServices konwerterServices)
        {
            this.konwerterservices = konwerterServices;
            this.scope = scope;
        }

        public List<IKonwerter> GetKonwerters()
        {
            List<IKonwerter> konwerters = this.konwerterservices.GetKonwerters();

            return konwerters;
        }

        [Route("api/konwerters/konwert")]
        [HttpGet]
        public decimal Konwerter(string jednostkaZ, string jednostkaDo, string wartosc,
        string konwerterType)
        {
            IKonwerter konwerter = this.konwerterservices.GetKonwerters()
                .Where(c => c.Name == konwerterType).FirstOrDefault();

            decimal output = konwerter.Konwerter(jednostkaZ, jednostkaDo, decimal.Parse(wartosc));

            return output;
        }     
    }
}