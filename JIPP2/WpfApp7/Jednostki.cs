using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppJIPP
{
    public class Jednostki
    {

        private string typmiary;
        private string nazwa;
        private bool czybazowa = false;
        

        public string Typmiary
        {
            get => typmiary;
            set => typmiary = value;
        }
        public string Nazwa
        {
            get => nazwa;
            set => nazwa = value;
        }
    
        public bool Czybazowa
        {
            get => czybazowa;
            set => czybazowa = value;
        }

        public Jednostki()
        {

        }

        public virtual double Konwersja_na_bazowa(double x)
        {
            return x;
        }
        public virtual double Konwersja_z_bazowej(double x)
        {
            return x;
        }
    }


    public class Celsjusz : Jednostki
    {

        public Celsjusz()
        {
            Typmiary = "temeratura";
            Nazwa = "celsjusz";
        }
        public override double Konwersja_na_bazowa(double x)
        {
         return (x+273.15);
        }
        public override double Konwersja_z_bazowej(double x)
        {
         return x-273.15;
        }
    }


    class Kelvin: Jednostki
    {
        public Kelvin()
        {
            Typmiary = "temeratura";
            Nazwa = "kelvin";
            Czybazowa = true;
        }
    }


    class Rankine : Jednostki
    {
        public Rankine()
        {
            Typmiary = "temeratura";
            Nazwa = "rankine";
        }
        public override double Konwersja_na_bazowa(double x)
        {
            return x/1.8;
        }
        public override double Konwersja_z_bazowej(double x)
        {
            return x*1.8;
        }
    }


    class Fahrenheit: Jednostki
    {
        public Fahrenheit()
        {
           Typmiary = "temeratura";
           Nazwa = "fahrenheit";
        }
        public override double Konwersja_na_bazowa(double x)
        {
          return (5/9)*(x+32)+273;
        }
        public override double Konwersja_z_bazowej(double x)
        {
          return 1.8*(x-273)+32;
        }
    }


    class Kilogram: Jednostki
    {
        public Kilogram()
        {
            Typmiary = "masa";
            Nazwa = "kilogram";
            Czybazowa = true;
        }
        public override double Konwersja_na_bazowa(double x)
        {
          return x;
        }
        public override double Konwersja_z_bazowej(double x)
        {
          return x;
        }
    }


    class Tona: Jednostki
    {
        public Tona()
        {
            Typmiary = "masa";
            Nazwa = "tona";
        }
        public override double Konwersja_na_bazowa(double x)
        {
          return x*1000;
        }
        public override double Konwersja_z_bazowej(double x)
        {
          return x/1000;
        }
    }


    class Gram : Jednostki
    {
        public Gram()
        {
            Typmiary = "masa";
            Nazwa = "gram";
        }
        public override double Konwersja_na_bazowa(double x)
        {
          return x*0.001;
        }
        public override double Konwersja_z_bazowej(double x)
        {
          return x/0.001;
        }
    }


    class Dekagram: Jednostki
    {
        public Dekagram()
        {
            Typmiary = "masa";
            Nazwa = "dekagram";
        }
        public override double Konwersja_na_bazowa(double x)
        {
          return x*0.01;
        }
        public override double Konwersja_z_bazowej(double x)
        {
          return x/0.01;
        }
    }

    class Karat : Jednostki
    {
        public Karat()
        {
            Typmiary = "masa";
            Nazwa = "karat";
        }
        public override double Konwersja_na_bazowa(double x)
        {
            return x*0.0002;
        }
        public override double Konwersja_z_bazowej(double x)
        {
            return x/0.0002;
        }
    }

    class Uncja : Jednostki
    {
        public Uncja()
        {
            Typmiary = "masa";
            Nazwa = "uncja";
        }
        public override double Konwersja_na_bazowa(double x)
        {
          return x*0.02835;
        }
        public override double Konwersja_z_bazowej(double x)
        {
          return x/0.02835;
        }
    }


    class Kwintal : Jednostki
    {
        public Kwintal()
        {
            Typmiary = "masa";
            Nazwa = "kwintal";
        }
        public override double Konwersja_na_bazowa(double x)
        {
            return x*100;
        }
        public override double Konwersja_z_bazowej(double x)
        {
            return x/100;
        }
    }


    class Funt : Jednostki
    {
        public Funt()
        {
            Typmiary = "masa";
            Nazwa = "funt";
        }
        public override double Konwersja_na_bazowa(double x)
        {
          return x*0.45359;
        }
        public override double Konwersja_z_bazowej(double x)
        {
          return x/0.45359;
        }
    }

    class Metr : Jednostki
    {
        public Metr()
        {
            Typmiary = "dlugosc";
            Nazwa = "metr";
            Czybazowa = true;
        }
    }


    class Milimetr : Jednostki
    {
        public Milimetr()
        {
            Typmiary = "dlugosc";
            Nazwa = "milimetr";
        }
        public override double Konwersja_na_bazowa(double x)
        {
            return x*0.001;
        }
        public override double Konwersja_z_bazowej(double x)
        {
            return x*1000;
        }
    }


    class Centymetr : Jednostki
    {
        public Centymetr()
        {
            Typmiary = "dlugosc";
            Nazwa = "centymetr";
        }
        public override double Konwersja_na_bazowa(double x)
        {
            return x*0.01;
        }
        public override double Konwersja_z_bazowej(double x)
        {
            return x*100;
        }
    }


    class Decymetr : Jednostki
    {
        public Decymetr()
        {
            Typmiary = "dlugosc";
            Nazwa = "decymetr";
        }
        public override double Konwersja_na_bazowa(double x)
        {
          return x*0.1;
        }
        public override double Konwersja_z_bazowej(double x)
        {
          return x*10;
        }
    }


    class Kilometr : Jednostki
    {
        public Kilometr()
        {
            Typmiary = "dlugosc";
            Nazwa = "kilometr";
        }
        public override double Konwersja_na_bazowa(double x)
        {
            return x*1000;
        }
        public override double Konwersja_z_bazowej(double x)
        {
            return x*0.001;
        }
    }

  
    class Mila : Jednostki
    {
        public Mila()
        {
            Typmiary = "dlugosc";
            Nazwa = "mila";
        }
        public override double Konwersja_na_bazowa(double x)
        {
            return x*1609.344;
        }
        public override double Konwersja_z_bazowej(double x)
        {
            return x/1609.344;
        }
    }


    class Jard : Jednostki
    {
        public Jard()
        {
            Typmiary = "dlugosc";
            Nazwa = "jard";
        }
        public override double Konwersja_na_bazowa(double x)
        {
          return x*0.9144;
        }
        public override double Konwersja_z_bazowej(double x)
        {
          return x/0.9144;
        }
    }


    class Stopa : Jednostki
    {
        public Stopa()
        {
            Typmiary = "dlugosc";
            Nazwa = "stopa";
        }
        public override double Konwersja_na_bazowa(double x)
        {
            return x*0.30480;
        }
        public override double Konwersja_z_bazowej(double x)
        {
            return x/0.30480;
        }
    }


    class Cal : Jednostki
    {
        public Cal()
        {
            Typmiary = "dlugosc";
            Nazwa = "cal";
        }
        public override double Konwersja_na_bazowa(double x)
        {
            return x*0.0254;
        }
        public override double Konwersja_z_bazowej(double x)
        {
            return x/0.0254;
        }
    }


    class Kabel : Jednostki
    {
        public Kabel()
        {
            Typmiary = "dlugosc";
            Nazwa = "kabel";
        }
        public override double Konwersja_na_bazowa(double x)
        {
          return x*185.2;
        }
        public override double Konwersja_z_bazowej(double x)
        {
          return x/185.2;
        }
    }


    class Milamorska : Jednostki
    {
        public Milamorska()
        {
            Typmiary = "dlugosc";
            Nazwa = "mila morska";
        }
        public override double Konwersja_na_bazowa(double x)
        {
          return x*1852;
        }
        public override double Konwersja_z_bazowej(double x)
        {
          return x/1852;
        }
    }
}


