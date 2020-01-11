using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Konwerter_jednostek.API
{
    public static class PobierzStatystyki
    {
        [FunctionName("PobierzStatystyki")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "PobierzStatystyki")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var connection = new ConnectToAzureV3();
            var statystyki = await connection.PobierzStatystykiAsync().ConfigureAwait(false);

            return new OkObjectResult(statystyki);
        }
    }
}
