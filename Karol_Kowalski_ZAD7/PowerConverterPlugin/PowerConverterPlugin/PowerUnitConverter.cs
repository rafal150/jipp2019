using UnitConverter.SDK;

namespace PowerConverterPlugin
{
    abstract class PowerUnitConverter: IUnitConverter
    {
        public string Type => "Moc";

        public abstract string Unit { get; }

        public abstract decimal ConvertFromSI(decimal value);

        public abstract decimal ConvertToSI(decimal value);
    }
}
