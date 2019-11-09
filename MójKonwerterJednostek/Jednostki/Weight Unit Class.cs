using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MójKonwerterJednostek.Jednostki
{
    class WeightUnit : Unit
    {
        public WeightUnit(double myValue, UnitTypes myType) : base(myValue, myType)
        { }
        public override void ChangeValue(double UnitUsed, UnitTypes UnitType)
        {

            switch (UnitType)
            {
                case UnitTypes.kg:
                    this.UnitSI = UnitUsed;
                    break;
                case UnitTypes.g:
                    this.UnitSI = UnitUsed / 1000;
                    break;
                case UnitTypes.dkg:
                    this.UnitSI = UnitUsed / 100;
                    break;
                case UnitTypes.mg:
                    this.UnitSI = UnitUsed / 1000000;
                    break;
                case UnitTypes.carat:
                    this.UnitSI = UnitUsed / 5000;
                    break;
                case UnitTypes.T:
                    this.UnitSI = UnitUsed * 1000;
                    break;
                case UnitTypes.ounce:
                    this.UnitSI = UnitUsed * 0.02834952;
                    break;
                case UnitTypes.pound:
                    this.UnitSI = UnitUsed * 0.45359237;
                    break;
                case UnitTypes.quintal:
                    this.UnitSI = UnitUsed * 100;
                    break;


            }
        }



        public override double ConvertUnit(UnitTypes UnitType)
        {

            switch (UnitType)
            {
                case UnitTypes.kg:
                    return this.UnitSI;

                case UnitTypes.g:
                    return this.UnitSI * 1000;

                case UnitTypes.dkg:
                    return this.UnitSI * 100;

                case UnitTypes.mg:
                    return this.UnitSI * 1000000;

                case UnitTypes.carat:
                    return this.UnitSI * 5000;

                case UnitTypes.T:
                    return this.UnitSI / 1000;

                case UnitTypes.ounce:
                    return this.UnitSI / 0.02834952;

                case UnitTypes.pound:
                    return this.UnitSI / 0.45359237;

                case UnitTypes.quintal:
                    return this.UnitSI / 100;
                default:
                    return -1;


            }
        }


    }

}
