using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;

namespace Konwerter5ZlotoPlugin
{
    class KursZlota
    {
        [JsonProperty("data")]
        public DateTimeOffset Data { get; set; }

        [JsonProperty("cena")]
        public double Cena
        {
            get; set;
        }

        public static KursZlota[] FromJson(string json) => JsonConvert.DeserializeObject<KursZlota[]>(json, JsonConverter.Settings);
    }
}


