using UnitConverter.SDK;

namespace UnitConverter.Logic.UnitConverters.Length
{
    abstract class LengthUnitConverter: IUnitConverter
    {
        public string Type => "Długość";

        public abstract string Unit { get; }

        public abstract decimal ConvertFromSI(decimal value);

        public abstract decimal ConvertToSI(decimal value);
    }
}
