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
    public class ConvertersController : ControllerBase
    {
        [HttpGet("ConverterTypes")]
        public ActionResult<Logic.ConverterTypes> Get()
        {
            Console.WriteLine("Request: ConverterTypes");
            var services = this.HttpContext.RequestServices;
            var converters = (Logic)services.GetService(typeof(Logic));
            return converters.getConverterTypes();
        }

        [HttpGet("ConverterUnits")]
        public ActionResult<Logic.Units> Get(string type)
        {
            Console.WriteLine("Request: ConverterUnits");
            var services = this.HttpContext.RequestServices;
            var converters = (Logic)services.GetService(typeof(Logic));
            return converters.getUnits(type);
        }

        [HttpGet("Converter")]
        public ActionResult<double> Get(string type, string from, string to, double value)
        {
            Console.WriteLine("Request: Converter");
            var services = this.HttpContext.RequestServices;
            var converters = (Logic)services.GetService(typeof(Logic));
            return converters.CheckUnits(type, from, to, value);
        }
    }
}
