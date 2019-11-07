using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Unit
    {
        private string typ = "";
        private bool bas = false;
        private string nam = "";
        private double val = 0;
        public string Typ { get => typ; set => typ = value; }
        public string Nam { get => nam; set => nam = value; }
        public double Val { get => val; set => val = value; }
        public bool Bas { get => bas; set => bas = value; }
        public Unit()
        {

        }
        public virtual double Con_to_base(double a)
        {
            return a;
        }
        public virtual double Con_from_base(double a)
        {
            return a;
        }
    }

    public class Cels:Unit
    {
        public Cels ()
        {
            Typ = "temperature";
            Nam = "celsius";
        }
        public override double Con_to_base(double a)
        {
            return a + 273.15;
        }
        public override double Con_from_base(double a)
        {
            return a - 273.15;
        }
    }

    class Kelv : Unit
    {
        public Kelv()
        {
            Typ = "temperature";
            Nam = "kelvin";
            Bas = true;
        }
    }

    class Fahr : Unit
    {
        public Fahr()
        {
            Typ = "temperature";
            Nam = "fahrenheit";
        }
        public override double Con_to_base(double a)
        {
            return (a + 459.67) / 1.8;
        }
        public override double Con_from_base(double a)
        {
            return (a * 1.8) - 459.67;
        }
    }

    class Rank : Unit
    {
        public Rank()
        {
            Typ = "temperature";
            Nam = "rankine";
        }
        public override double Con_to_base(double a)
        {
            return a / 1.8;
        }
        public override double Con_from_base(double a)
        {
            return a * 1.8;
        }
    }

    class Metr: Unit
    {
        public Metr()
        {
            Typ = "lenght";
            Nam = "metre";
            Bas = true;
        }
    }

    class Dmetr : Unit
    {
        public Dmetr()
        {
            Typ = "lenght";
            Nam = "decymetre";
        }
        public override double Con_to_base(double a)
        {
            return a * 0.1;
        }
        public override double Con_from_base(double a)
        {
            return a * 10;
        }
    }

    class Cmetr : Unit
    {
        public Cmetr()
        {
            Typ = "lenght";
            Nam = "centymetre";
        }
        public override double Con_to_base(double a)
        {
            return a * 0.01;
        }
        public override double Con_from_base(double a)
        {
            return a * 100;
        }
    }

    class Mmetr : Unit
    {
        public Mmetr()
        {
            Typ = "lenght";
            Nam = "milimetre";
        }
        public override double Con_to_base(double a)
        {
            return a * 0.001;
        }
        public override double Con_from_base(double a)
        {
            return a * 1000;
        }
    }

    class Kmetr : Unit
    {
        public Kmetr()
        {
            Typ = "lenght";
            Nam = "kilometre";
        }
        public override double Con_to_base(double a)
        {
            return a * 1000;
        }
        public override double Con_from_base(double a)
        {
            return a * 0.001;
        }
    }

    class Nauticalm : Unit
    {
        public Nauticalm ()
        {
            Typ = "lenght";
            Nam = "nautical mile";
        }
        public override double Con_to_base(double a)
        {
            return a * 1852;
        }
        public override double Con_from_base(double a)
        {
            return a / 1852;
        }
    }

    class Nauticalcable : Unit
    {
        public Nauticalcable()
        {
            Typ = "lenght";
            Nam = "cable";
        }
        public override double Con_to_base(double a)
        {
            return a * 185.2;
        }
        public override double Con_from_base(double a)
        {
            return a / 185.2;
        }
    }

    class Inch: Unit
    {
        public Inch()
        {
            Typ = "lenght";
            Nam = "inch";
        }
        public override double Con_to_base(double a)
        {
            return a * 0.0254;
        }
        public override double Con_from_base(double a)
        {
            return a / 0.0254;
        }
    }

    class Foot : Unit
    {
        public Foot()
        {
            Typ = "lenght";
            Nam = "foot";
        }
        public override double Con_to_base(double a)
        {
            return a * 0.30480;
        }
        public override double Con_from_base(double a)
        {
            return a / 0.30480;
        }
    }

    class Yard : Unit
    {
        public Yard()
        {
            Typ = "lenght";
            Nam = "yard";
        }
        public override double Con_to_base(double a)
        {
            return a * 0.9144;
        }
        public override double Con_from_base(double a)
        {
            return a / 0.9144;
        }
    }

    class Mile : Unit
    {
        public Mile()
        {
            Typ = "lenght";
            Nam = "mile";
        }
        public override double Con_to_base(double a)
        {
            return a * 1609.344;
        }
        public override double Con_from_base(double a)
        {
            return a / 1609.344;
        }
    }

    class Kilogram : Unit
    {
        public Kilogram()
        {
            Typ = "weight";
            Nam = "kilogram";
            Bas = true;
        }
        public override double Con_to_base(double a)
        {
            return a ;
        }
        public override double Con_from_base(double a)
        {
            return a ;
        }
    }

    class Gram : Unit
    {
        public Gram()
        {
            Typ = "weight";
            Nam = "gram";
        }
        public override double Con_to_base(double a)
        {
            return a*0.001;
        }
        public override double Con_from_base(double a)
        {
            return a/ 0.001;
        }
    }

    class Dgram : Unit
    { 
        public Dgram()
        {
            Typ = "weight";
            Nam = "decagram";
        }
        public override double Con_to_base(double a)
        {
            return a * 0.01;
        }
        public override double Con_from_base(double a)
        {
            return a / 0.01;
        }
    }

    class Tonne : Unit
    {
        public Tonne()
        {
            Typ = "weight";
            Nam = "tonne";
        }
        public override double Con_to_base(double a)
        {
            return a * 1000;
        }
        public override double Con_from_base(double a)
        {
            return a / 1000;
        }
    }

    class Ounce : Unit
    {
        public Ounce()
        {
            Typ = "weight";
            Nam = "ounce";
        }
        public override double Con_to_base(double a)
        {
            return a * 0.02834952981;
        }
        public override double Con_from_base(double a)
        {
            return a / 0.02834952981;
        }
    }

    class Pound : Unit
    {
        public Pound()
        {
            Typ = "weight";
            Nam = "pound";
        }
        public override double Con_to_base(double a)
        {
            return a * 0.45359237;
        }
        public override double Con_from_base(double a)
        {
            return a / 0.45359237;
        }
    }

    class Carat : Unit
    {
        public Carat()
        {
            Typ = "weight";
            Nam = "carat";
        }
        public override double Con_to_base(double a)
        {
            return a * 0.0002;
        }
        public override double Con_from_base(double a)
        {
            return a / 0.0002;
        }
    }

    class Quintal : Unit
    {
        public Quintal()
        {
            Typ = "weight";
            Nam = "quintal";
        }
        public override double Con_to_base(double a)
        {
            return a * 100;
        }
        public override double Con_from_base(double a)
        {
            return a / 100;
        }
    }
}