using Newtonsoft.Json;
using System;
using System.Diagnostics.Contracts;

namespace Konwerter8000WalutyPlugin
{
    public class TabeleKursow
    {

        [JsonProperty("table")]
        public string Table { get; set; }

        [JsonProperty("no")]
        public string No { get; set; }

        [JsonProperty("effectiveDate")]
        public DateTimeOffset EffectiveDate { get; set; }

        [JsonProperty("rates")]
        public Rate[] Rates { get; set; }

        public static TabeleKursow[] FromJson(string json)
        {
            Contract.Ensures(Contract.Result<TabeleKursow>() != null);
            return JsonConvert.DeserializeObject<TabeleKursow[]>(json, JsonConverter.Settings);
        }
    }
}