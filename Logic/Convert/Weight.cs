using System.Collections.Generic;

namespace Logic.Convert
{
    public class Weight : ConverterSDK.ConverterInterface
    {
        private double gram;
        public string name;

        public Weight()
        {
            this.name = this.GetType().Name;
        }
        public double Gram
        {
            get { return this.gram; }
            set { this.gram = value; }
        }
        public double Miligram
        {
            get { return this.gram * 1000; }
            set { this.gram = value / 1000; }
        }
        public double Dekagram
        {
            get { return this.gram * 0.1; }
            set { this.gram = value / 0.1; }
        }
        public double Kilogram
        {
            get { return this.gram * 0.001; }
            set { this.gram = value / 0.001; }
        }
        public double Ton
        {
            get { return this.gram * 0.000001; }
            set { this.gram = value / 0.000001; }
        }
        public double Pound
        {
            get { return this.gram * 0.0022; }
            set { this.gram = value / 0.0022; }
        }
        public double Ounce
        {
            get { return this.gram * 0.0352; }
            set { this.gram = value / 0.0352; }
        }
        public double Carat
        {
            get { return this.gram * 5; }
            set { this.gram = value / 5; }
        }
        public double Quintal
        {
            get { return this.gram * 0.00001; }
            set { this.gram = value / 0.00001; }
        }


        public static List<string> GetListOfProperties()
        {
            List<string> array = new List<string>();
            foreach(var prop in typeof(Weight).GetProperties())
            {
                array.Add(prop.Name);
            }
            return array;
        }
    }
}