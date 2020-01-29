using Newtonsoft.Json;

namespace Konwerter8000WalutyPlugin
{  
        public class Rate
        {
            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("mid")]
            public double Mid { get; set; }
        }

}