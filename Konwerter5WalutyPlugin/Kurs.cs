using System;
using System.Linq;
using System.Net;
using System.Globalization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics.Contracts;

namespace Konwerter5WalutyPlugin
{
    public partial class TabeleKursow
    {
       
        public static TabeleKursow FromJson(string json)
        {
            Contract.Ensures(Contract.Result<TabeleKursow>() != null);
            return JsonConvert.DeserializeObject<TabeleKursow>(json, JsonConverter.Settings);
        }
    }

    static class JsonConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
            },
        };
    }
}
