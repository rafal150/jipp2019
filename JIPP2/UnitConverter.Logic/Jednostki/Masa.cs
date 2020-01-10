using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonwerterSDK;
namespace WpfApp7.Jednostki
{
    class Masa : InterfejsKonwerter
    {
        public double kilogram;
        public double Kilogram
        {
            get { return this.kilogram; }
            set { this.kilogram = value; }
        }
        public double Tona
        {
            get { return this.kilogram/1000; }
            set { this.kilogram = value*1000; }
        }
        public double Dekagram
        {
            get { return this.kilogram*100; }
            set { this.kilogram = value/ 100; }
        }
        public double Gram
        {
            get { return this.kilogram*1000; }
            set { this.kilogram = value / 1000;  }
        }
        public double Kwintal
        {
            get { return this.kilogram * 0.01; }
            set { this.kilogram = value / 0.01; }
        }
        public double Funt
        {
            get { return this.kilogram * 2.203; }
            set { this.kilogram = value /2.203; }
        }
        public double Uncja
        {
            get { return this.kilogram * 0.0352; }
            set { this.kilogram = value / 0.0352; }
        }
        public double Karat
        {
            get { return this.kilogram * 5000; }
            set { this.kilogram = value / 5; }
        }
       
        


        public static List<string> GetJednostki()
        {
            List<string> array = new List<string>();
            foreach (var prop in typeof(Masa).GetProperties())
            {
                array.Add(prop.Name);
            }
            return array;
        }
    }
}
