using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Konwerter5ZlotoPlugin
{
   static class JsonConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
            }
        };

    }
}
