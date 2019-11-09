using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MójKonwerterJednostek.Jednostki
{
    class LengthUnit : Unit
    {

        public LengthUnit(double myValue, UnitTypes myType) : base(myValue, myType)
        { }
        public override void ChangeValue(double UnitUsed, UnitTypes UnitType)
        {

            switch (UnitType)
            {
                case UnitTypes.mm:
                    this.UnitSI = UnitUsed / 1000;
                    break;
                case UnitTypes.m:
                    this.UnitSI = UnitUsed;
                    break;
                case UnitTypes.cm:
                    this.UnitSI = UnitUsed / 100;
                    break;
                case UnitTypes.dm:
                    this.UnitSI = UnitUsed / 10;
                    break;
                case UnitTypes.km:
                    this.UnitSI = UnitUsed * 1000;
                    break;
                case UnitTypes.inch:
                    this.UnitSI = UnitUsed * 0.0254;
                    break;
                case UnitTypes.foot:
                    this.UnitSI = UnitUsed * 0.3048;
                    break;
                case UnitTypes.yard:
                    this.UnitSI = UnitUsed / 1.0936;
                    break;
                case UnitTypes.mile:
                    this.UnitSI = UnitUsed * 1609.344;
                    break;
                case UnitTypes.cable_length:
                    this.UnitSI = UnitUsed * 185.2;
                    break;
                case UnitTypes.nautical_mile:
                    this.UnitSI = UnitUsed * 1852;
                    break;

            }
        }

        public override double ConvertUnit(UnitTypes UnitType)
        {
            switch (UnitType)
            {
                case UnitTypes.mm:
                    return this.UnitSI * 1000;

                case UnitTypes.m:
                    return this.UnitSI;

                case UnitTypes.cm:
                    return this.UnitSI * 100;

                case UnitTypes.dm:
                    return this.UnitSI * 10;

                case UnitTypes.km:
                    return this.UnitSI / 1000;

                case UnitTypes.inch:
                    return this.UnitSI / 0.0254;

                case UnitTypes.foot:
                    return this.UnitSI / 0.3048;

                case UnitTypes.yard:
                    return this.UnitSI * 1.0936;

                case UnitTypes.mile:
                    return this.UnitSI / 1609.344;

                case UnitTypes.cable_length:
                    return this.UnitSI / 185.2;

                case UnitTypes.nautical_mile:
                    return this.UnitSI / 1852;
                default:
                    return -1;
            }
        }
    }
}
