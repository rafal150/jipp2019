using System;

namespace CurrencyConverterPlugin.CurrencyWebApi.Rates
{
    public class RateEntry
    {
        public string No { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public decimal Mid { get; set; }
    }
}
