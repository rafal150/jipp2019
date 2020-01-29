using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;


namespace Konwerter8000.WAPI.Controllers
{
    public class LogController : ApiController
    {
        ILog Log;

        public LogController(ILog log)
        {
            Log = log;
        }
        [Route("api/log/pobierz")]
        [HttpGet]
        public IEnumerable<LogDTO> GetLog()
        {
            //try
           // {
                return Log.PobierzLog();
                
          //  }
          //  catch
          //  {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
         //   }
        }

        [Route("api/log/dodaj")]
        [HttpGet]
        public void SetLog(LogDTO logDTO)
        {
            try
            {
                Log.DodajLog(logDTO);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}