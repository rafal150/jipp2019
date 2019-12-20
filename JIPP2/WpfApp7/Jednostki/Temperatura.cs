using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonwerterSDK;
namespace WpfApp7.Jednostki
{
    class Temperatura : InterfejsKonwerter
    {
        public double celsiusz;
        public double Celsiusz
        {
            get { return this.celsiusz; }
            set { this.celsiusz = value; }
        }
        public double Farenheit
        {
            get { return this.celsiusz * 9 / 5 + 32; }
            set { this.celsiusz = (value - 32) * 5 / 9; }
        }
        public double Kelvin
        {
            get { return this.celsiusz + 273.15; }
            set { this.celsiusz = value - 273.15; }
        }
        public double Rankine
        {
            get { return (this.celsiusz + 273.15) * 9 / 5; }
            set { this.celsiusz = (value - 491.67) * 5 / 9; }
        }


        public static List<string> GetJednostki()
        {
            List<string> array = new List<string>();
            foreach (var prop in typeof(Temperatura).GetProperties())
            {
                array.Add(prop.Name);
            }
            return array;
        }
    }
}
