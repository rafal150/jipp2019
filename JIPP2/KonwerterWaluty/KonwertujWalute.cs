using KonwerterSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterWaluty
{
    public class KonwertujWalute : InterfejsKonwerter
    {
        private PobierzKurs pobierzKurs;
        private double pln;
        private double kursWaluty;
        public KonwertujWalute()
        {
            this.pobierzKurs = new PobierzKurs();
            this.kursWaluty = double.Parse(this.pobierzKurs.DajKurs("EUR").ToString());
        }
        public double PLN
        {
            get { return this.pln; }
            set { this.pln = value; }
        }
        public double EUR
        {
            get { return this.pln / kursWaluty; }
            set { this.pln = value * kursWaluty; }
        }

        public static List<string> GetJednostki()
        {
            List<string> array = new List<string>();
            foreach (var prop in typeof(KonwertujWalute).GetProperties())
            {
                array.Add(prop.Name);
            }
            return array;
        }
    }
}

