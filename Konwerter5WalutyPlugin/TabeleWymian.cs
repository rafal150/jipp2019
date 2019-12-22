using Newtonsoft.Json;
namespace Konwerter5WalutyPlugin
{
    public class TabeleWymian
    {
        [JsonProperty("no")]
        public string No { get; set; }
        [JsonProperty("effectiveDate")]
        public string EffectiveDate { get; set; }
        [JsonProperty("mid")]
        public double Mid { get; set; }
    }
}
