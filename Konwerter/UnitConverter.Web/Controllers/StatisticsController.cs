using Konwerter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UnitConverter.Web.Controllers
{
    public class StatisticsController : ApiController
    {
        private IStatystykiRepo repozytorium;
        
        [Route("api/converters/show")]
        [HttpGet]
        public IEnumerable<StatystykiObiekt> GetStatistics()
        {
            //IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;
            IEnumerable<StatystykiObiekt> rekordy = this.repozytorium.GetStatistics();
            return rekordy;
        }
    }
}
