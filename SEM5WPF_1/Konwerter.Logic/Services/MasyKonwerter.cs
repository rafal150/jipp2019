using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEM5WPF_1.Services;

namespace SEM5WPF_1.Services
{
    class MasyKonwerter : IKonwerter
    {
        public string Name => "Masy";

        public List<string> Units => new List<string>(new[] { "mg", "g","dkg","kg","t","uncja","funt","karat" });

        public decimal Konwerter(string jednostkaZ, string jednostkaDo, decimal wartosc)
        {
           // double Z, W;
 
/*
            if (jednostkaDo == "uncja")
            {
                return wartosc * 0.0031274M);
            }
            else if (jednostkaDo == "funt")
            {
               return (wartosc / 0.00022046M);
            }
            else if (jednostkaDo == "karat")
            {
               return (wartosc * 0.5M);
            }
            else
            {
                return (wartosc * 0.000001M);
            } */

            switch (jednostkaZ)
            {

                case "mg":
                   return wartosc * 1; 
                    
                case "g":
                    return wartosc * 10; 
                    
                case "dkg":
                    return wartosc * 100;
                   
                case "kg":
                    return wartosc * 10000; 
                    
                case "t":
                    return wartosc * 100000; 
                    
            }
            return wartosc;
        }
    }
}
