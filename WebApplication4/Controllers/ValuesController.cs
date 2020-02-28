using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConverterLogic;
using Newtonsoft.Json.Linq;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IConverter _converter;

        public ValuesController(IConverter converter)
        {
            _converter = converter;
        }

        [HttpGet("from")]
        public ActionResult<IEnumerable<string>> GetFrom()
        {
            return _converter.GetKeysFrom();
        }

        [HttpGet("{id}/to")]
        public ActionResult<IEnumerable<string>> GetTo(string id)
        {
            return _converter.GetKeysTo(id);
        }

        [HttpPost]
        public ActionResult<double> Calc([FromBody] dynamic data)
        {
            return _converter.Convert(data["from"].ToString(), data["to"].ToString(), Int32.Parse(data["value"].ToString()));
        }
    }
}
