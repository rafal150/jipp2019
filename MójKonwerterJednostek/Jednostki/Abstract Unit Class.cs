using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MójKonwerterJednostek.Jednostki
{
    abstract class Unit
    {




        protected double UnitSI;
        public Unit(double UnitValue, UnitTypes UnitType)
        { this.ChangeValue(UnitValue, UnitType); }
        public abstract void ChangeValue(double UnitUsed, UnitTypes UnitType);

        public abstract double ConvertUnit(UnitTypes UnitType);

    }
}
