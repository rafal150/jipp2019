using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MójKonwerterJednostek.Jednostki
{
    class TemperatureUnit : Unit
    {

        public TemperatureUnit(double myValue, UnitTypes myType) : base(myValue, myType)
        { }

        public override void ChangeValue(double UnitUsed, UnitTypes UnitType)
        {

            switch (UnitType)
            {
                case UnitTypes.Celsius:
                    this.UnitSI = UnitUsed + 273.15;
                    break;
                case UnitTypes.Farenheit:
                    this.UnitSI = (UnitUsed + 459.67) * (5.0 / 9.0);
                    break;
                case UnitTypes.Kelvin:
                    this.UnitSI = UnitUsed;
                    break;
                case UnitTypes.Rankine:
                    this.UnitSI = UnitUsed * (5.0 / 9.0);
                    break;

            }
        }

        public override double ConvertUnit(UnitTypes UnitType)
        {

            switch (UnitType)
            {
                case UnitTypes.Celsius:
                    return this.UnitSI - 273.15;

                case UnitTypes.Farenheit:
                    return (this.UnitSI * (9.0 / 5.0)) - 459.67;

                case UnitTypes.Kelvin:
                    return this.UnitSI;

                case UnitTypes.Rankine:
                    return this.UnitSI * (9.0 / 5.0);
                default:
                    return -1;


            }
        }
    }

}
