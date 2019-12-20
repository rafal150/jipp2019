using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonwerterSDK;

namespace Predkosc
{
    public class Predkosc : InterfejsKonwerter
    {
        public double kmh;
        public double kmph
        {
            get { return this.kmh; }
            set { this.kmh = value; }
        }

        public double meph
        {
            get { return this.kmh / 3.6; }
            set { this.kmh = value * 3.6; }
        }

        public double mph
        {
            get { return this.kmh / 1.609344; }
            set { this.kmh = value * 1.609344; }
        }

        public static List<string> GetJednostki()
        {
            List<string> array = new List<string>();
            foreach (var prop in typeof(Predkosc).GetProperties())
            {
                array.Add(prop.Name);
            }
            return array;
        }
    }
}
