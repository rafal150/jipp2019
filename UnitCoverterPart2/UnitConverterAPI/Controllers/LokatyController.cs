using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Converters;

namespace UnitConverterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LokatyController : ControllerBase
    {
        [HttpGet("Lokaty")]
        public ActionResult<List<int>> Get()
        {
            Console.WriteLine("Request: Lokaty");
            var services = this.HttpContext.RequestServices;
            var lokaty = (Lokaty.Lokaty)services.GetService(typeof(Lokaty.Lokaty));
            return lokaty.GetLokaty();
        }

        [HttpGet("Przelicz")]
        public ActionResult<double> Get(int lokata, int okres, double value)
        {
            Console.WriteLine("Request: Przelicz");
            var services = this.HttpContext.RequestServices;
            var lokaty = (Lokaty.Lokaty)services.GetService(typeof(Lokaty.Lokaty));
            return lokaty.policzKapital(lokata, okres, value);
        }
    }
}
