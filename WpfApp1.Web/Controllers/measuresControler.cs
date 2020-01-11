using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WpfApp1.Logic;
using WpfApp1.SDK;
using Autofac;

namespace WpfApp1.Web
{
    public class measuresController : ApiController
    {
        private GetMeasuresObj measuresService;
        private ILifetimeScope scope;

        public measuresController(ILifetimeScope scope, GetMeasuresObj convertersMesure)
        {
            this.measuresService = convertersMesure;
            this.scope = scope;
        }

        public List<IGetMeasures> GetMesasures()
        {
            List<IGetMeasures> measures = this.measuresService.GetMesasures();

            return measures;
        }

        [Route("api/measures/convert")]
        [HttpGet]
        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public double Convert(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            IGetMeasures converter = this.measuresService.GetMesasures()
               .Where(c => c.Nam == converterType).FirstOrDefault();

            double output = converter.Convert(unitFrom, unitTo, double.Parse(valueToConvert));

            return output;
        }
    }
}
