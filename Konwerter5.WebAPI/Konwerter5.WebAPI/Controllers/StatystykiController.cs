using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Konwerter5.Uslugi;
using Konwerter5;

namespace Konwerter5.WebAPI.Controllers
{
    public class StatystykiController : ApiController
    {
        IRepozytoriumStatystykUzycia RepozytoriumStatystyk;

        
        public StatystykiController(IRepozytoriumStatystykUzycia repozytorium)
        {
            RepozytoriumStatystyk = repozytorium;
        }
        [Route("api/statystki/pobierz")]
        [HttpGet]
        public IEnumerable<StatystykiUzyciaDTO> GetStatystykiUzycia() {
            
            try
            { 
                var _statystyki = RepozytoriumStatystyk.PobierzStatystykiUzycia();
                return _statystyki;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

        }

        [Route("api/statystyki/dodaj")]
        [HttpGet]
        public void SetStatystykiUzycia(StatystykiUzyciaDTO statystyka) 
        {
            try
            { 
                RepozytoriumStatystyk.DodajStatystykiUzycia(statystyka);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

    }
}
