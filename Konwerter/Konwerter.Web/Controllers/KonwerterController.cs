using Autofac;
using Konwerter.SDK;
using Konwerter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Konwerter.Web.Controllers
{
    public class KonwerterController : ApiController
    {
        private ConvertersService convertersService;
        private IRepo repo;
        private ILifetimeScope scope;

        public KonwerterController(ILifetimeScope scope, ConvertersService convertersService, IRepo repo)
        {
            this.convertersService = convertersService;
            this.repo = repo;
            this.scope = scope;
        }

        public List<IKonwerter> GetConverters()
        {
            List<IKonwerter> konwertery = this.convertersService.GetConverters();

            return konwertery;
        }

        [Route("api/konwerter/przelicz")]
        [HttpGet]
        public double Przelicz(string FromUnit, string ToUnit, string valueToConvert, string converterType, string repo)
        {
            //IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;
            if (repo == "Azure")
                this.repo = new AzureStorageRepo();
            else this.repo = new SqlRepo();
            IKonwerter konwerter = this.convertersService.GetConverters()
                .Where(c => c.Typ == converterType).FirstOrDefault();
            double value = double.Parse(valueToConvert);
            double output = konwerter.Przelicz(FromUnit, ToUnit, value);
            
            RekordDTO rekord = new RekordDTO();
            rekord.DateTime = DateTime.Now;
            rekord.Type = converterType;
            rekord.FromUnit = FromUnit;
            rekord.ToUnit = ToUnit;
            rekord.RawValue = value.ToString();
            rekord.ConvertedValue = output.ToString();
            this.repo.dodajRekord(rekord);
            return output;
        }

        [Route("api/konwerter/pokaz")]
        [HttpGet]
        public IEnumerable<RekordDTO> pobierzRekordy(string repo)
        {
            if (repo == "Azure")
                this.repo = new AzureStorageRepo();
            else this.repo = new SqlRepo();
            //IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;
            IEnumerable<RekordDTO> rekordy = this.repo.pobierzRekordy();
            return rekordy;
        }

        [Route("api/konwerter/wyczysc")]
        [HttpGet]
        public void wyczyscHistorie(string repo)
        {
            if (repo == "Azure")
                this.repo = new AzureStorageRepo();
            else this.repo = new SqlRepo();
            this.repo.wyczyscHistorie();
        }
    }
}