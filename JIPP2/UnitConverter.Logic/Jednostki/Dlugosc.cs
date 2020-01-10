using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonwerterSDK;
namespace WpfApp7.Jednostki


{
    class Dlugosc : InterfejsKonwerter
    {
        public double metr;
        public double Metr
        {
            get { return this.metr; }
            set { this.metr = value; }
        }
        public double Kilometr
        {
            get { return this.metr / 1000; }
            set { this.metr = value * 1000; }
        }
        public double Centymetr
        {
            get { return this.metr * 100; }
            set { this.metr = value / 100; }
        }
        public double Millimetr
        {
            get { return this.metr * 1000; }
            set { this.metr = value / 1000; }
        }
        public double Decymetr
        {
            get { return this.metr * 10; }
            set { this.metr = value / 10; }
        }
        public double Stopa
        {
            get { return this.metr * 3.2808; }
            set { this.metr = value / 3.2808; }
        }
        public double Jard
        {
            get { return this.metr * 1.0936; }
            set { this.metr = value / 1.0936; }
        }
        public double Cal
        {
            get { return this.metr * 39.37; }
            set { this.metr = value / 39.37; }
        }
        public double Mila
        {
            get { return this.metr * 0.000621; }
            set { this.metr = value / 0.000621; }
        }
        public double Mila_morska
        {
            get { return this.metr * 0.0005399; }
            set { this.metr = value / 0.0005399; }
        }
       
       
        public double Kabel
        {
            get { return this.metr * 0.005399; }
            set { this.metr = value / 0.005399; }
        }


        public static List<string> GetJednostki()
        {
            List<string> array = new List<string>();
            foreach (var prop in typeof(Dlugosc).GetProperties())
            {
                array.Add(prop.Name);
            }
            return array;
        }
    }
}
