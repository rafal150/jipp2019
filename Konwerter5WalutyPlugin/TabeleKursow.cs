using Newtonsoft.Json;
namespace Konwerter5WalutyPlugin
{
    public partial class TabeleKursow
    {
        [JsonProperty("table")]
        public string Table { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("rates")]
        public TabeleWymian[] Rates { get; set; }
    }
}
