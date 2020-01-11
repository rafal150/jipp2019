using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Konwerter_jednostek.API
{
    public static class Konwertuj
    {
        [FunctionName("Konwertuj")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Konwertuj")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string value = req.Query["value"];
            int inputMiaraID = Convert.ToInt32(req.Query["inputMiaraID"]);
            int outputMiaraID = Convert.ToInt32(req.Query["outputMiaraID"]);

            ILogic logic = new Logic();
            ConnectToAzureV3 conn = new ConnectToAzureV3();

            return new OkResult();
        }
    }
}
