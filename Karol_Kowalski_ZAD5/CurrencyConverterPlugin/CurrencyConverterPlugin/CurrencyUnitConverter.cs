using CurrencyConverterPlugin.CurrencyWebApi.Rates;
using UnitConverter.SDK;

namespace CurrencyConverterPlugin
{
    abstract class CurrencyUnitConverter : IUnitConverter
    {
        public string Type => "Waluta";

        public abstract string Code { get; }

        public abstract string Unit { get; }

        public virtual decimal ConvertFromSI(decimal value)
        {
            var rate = RatesService.GetLastRate(Code);

            return rate != null
                ? value * rate.Value
                : 0.0m;
        }

        public virtual decimal ConvertToSI(decimal value)
        {
            var rate = RatesService.GetLastRate(Code);

            return rate != null
                ? value / rate.Value
                : 0.0m;
        }
    }
}
