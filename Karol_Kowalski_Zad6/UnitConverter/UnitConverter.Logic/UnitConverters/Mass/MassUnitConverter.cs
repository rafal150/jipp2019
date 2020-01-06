using UnitConverter.SDK;

namespace UnitConverter.Logic.UnitConverters.Mass
{
    abstract class MassUnitConverter: IUnitConverter
    {
        public string Type => "Masa";

        public abstract string Unit { get; }

        public abstract decimal ConvertFromSI(decimal value);

        public abstract decimal ConvertToSI(decimal value);
    }
}
