namespace CurrencyConverterPlugin
{
    class PlnUnitConverter : CurrencyUnitConverter
    {
        public override string Unit => "PLN";

        public override string Code => "PLN";

        public override decimal ConvertFromSI(decimal value)
        {
            return value;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value;
        }
    }
}
