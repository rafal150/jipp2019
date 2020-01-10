using UnitConverter.SDK;

namespace UnitConverter.Logic.UnitConverters.Temperature
{
    abstract class TemperatureUnitConverter : IUnitConverter
    {
        public string Type => "Temperatura";

        public abstract string Unit { get; }

        public abstract decimal ConvertFromSI(decimal value);

        public abstract decimal ConvertToSI(decimal value);
    }
}
