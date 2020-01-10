using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCoverterPart2.Services;

namespace IloscPlugin
{
    class IloscConverter : IConverter
    {
        public string Name => "Ilości";

        public List<string> Units => new List<string>(new[] { "Megabajt", "Gigabajt", "Terabajt" });

        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == "Megabajt" && unitTo == "Gigabajt")       
            {
                value = value / 1024;

            }
            if (unitFrom == "Megabajt" && unitTo == "Terabajt")       
            {
                value = value / 1048576;

            }
            if (unitFrom == "Gigabajt" && unitTo == "Megabajt")        
            {
                value = value * 1024;

            }
            if (unitFrom == "Gigabajt" && unitTo == "Terabajt")       
            {
                value = value / 1024 ;

            }
            if (unitFrom == "Terabajt" && unitTo == "Megabajt")        
            {
                value = value * 1048576;

            }
            if (unitFrom == "Terabajt" && unitTo == "Gigabajt")        
            {
                value = value * 1024;

            }
            return value;
        }
        }

}
