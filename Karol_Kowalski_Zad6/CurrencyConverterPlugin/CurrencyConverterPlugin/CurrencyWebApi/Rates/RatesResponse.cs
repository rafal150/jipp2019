namespace CurrencyConverterPlugin.CurrencyWebApi.Rates
{
    public class RatesResponse
    {
        public string Table { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public RateEntry[] Rates { get; set; }
    }
}
