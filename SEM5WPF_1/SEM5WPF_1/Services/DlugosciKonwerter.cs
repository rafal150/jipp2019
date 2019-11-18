using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter.SDK;

namespace SEM5WPF_1.Services
{
    class DlugosciKonwerter : IKonwerter
    {
        public string Name => "Długośći";

        public List<string> Units => new List<string>(new[] { "mm","cm","dm","m","km","cal","stopa","yard","mila","kabel","mila morska" });

        public decimal Konwerter(string jednostkaZ, string jednostkaDo, decimal wartosc)
        {
            
            decimal Z, W, Y = 1.09361M, Ft = 3.28M, Inch = 39.37M;
            
          

            switch (jednostkaZ)
            {
                case "mm":
                    if (jednostkaDo == "yard")
                    {
                        return (wartosc / 1000) * Y; 
                    }
                    else if (jednostkaDo == "stopa")
                    {
                        return (wartosc / 1000) * Ft;
                    }
                    else if (jednostkaDo == "cal")
                    {
                        return (wartosc / 1000) * Inch;
                    }
                    else if (jednostkaDo == "mila")
                    {
                        return (wartosc * 0.000000621M);
                    }
                    else if (jednostkaDo == "kabel")
                    {
                        return (wartosc / 1000) * 0.0053993M; 
                    }
                    else
                    {
                        return (wartosc / 1000) * 0.000539957M;
                    }
                    
                case "cm":
                    if (jednostkaDo == "yard")
                    {
                        return (wartosc / 100) * Y;
                    }
                    else if (jednostkaDo == "stopa")
                    {
                        return (wartosc / 100) * Ft;
                    }
                    else if (jednostkaDo == "cal")
                    {
                        return (wartosc / 100) * Inch; 
                    }
                    else if (jednostkaDo == "mila")
                    {
                        return (wartosc * 0.00000621M);
                    }
                    else if (jednostkaDo == "kabel")
                    {
                        return (wartosc / 100) * 0.0053993M;
                    }
                    else
                    {
                        return (wartosc / 100) * 0.000539957M; 
                    }
                    
                case "dm":
                    if (jednostkaDo == "yard")
                    {
                        return (wartosc / 10) * Y; 
                    }
                    else if (jednostkaDo == "stopa")
                    {
                        return (wartosc / 10) * Ft;
                    }
                    else if (jednostkaDo == "cal")
                    {
                        return (wartosc / 10) * Inch; 
                    }
                    else if (jednostkaDo == "mila")
                    {
                        return (wartosc * 0.0000621M);
                    }
                    else if (jednostkaDo == "kabel")
                    {
                        return (wartosc / 10) * 0.0053993M;
                    }
                    else
                    {
                        return (wartosc / 10) * 0.000539957M; 
                    }
                    
                case "m":
                    if (jednostkaDo == "yard")
                    {
                        return wartosc * Y;
                    }
                    else if (jednostkaDo == "stopa")
                    {
                        return wartosc * Ft; 
                    }
                    else if (jednostkaDo == "cal")
                    {
                        return wartosc * Inch; 
                    }
                    else if (jednostkaDo == "mila")
                    {
                        return (wartosc * 0.000621M);
                    }
                    else if (jednostkaDo == "kabel")
                    {
                        return wartosc * 0.0053993M;
                    }
                    else
                    {
                        return wartosc * 0.000539957M;
                    }
                    //break;
                case "km":
                    if (jednostkaDo == "yard")
                    {
                        return (wartosc * 1000) * Y;
                    }
                    else if (jednostkaDo == "stopa")
                    {
                        return (wartosc * 1000) * Ft;
                    }
                    else if (jednostkaDo == "cal")
                    {
                        return (wartosc * 1000) * Inch; 
                    }
                    else if (jednostkaDo == "mila")
                    {
                        return (wartosc * 0.621M); 
                    }
                    else if (jednostkaDo == "kabel")
                    {
                        return (wartosc * 1000) * 0.0053993M;
                    }
                    else
                    {
                        return (wartosc * 1000) * 0.000539957M; 
                    }
                    //break;
                case "cal":
                    if (jednostkaDo == "mm")
                    {
                        return (wartosc * 25.4M); 
                    }
                    else if (jednostkaDo == "cm")
                    {
                        return (wartosc * 2.54M) * Ft; 
                    }
                    else if (jednostkaDo == "dm")
                    {
                        return (wartosc * 0.254M) * Inch; 
                    }
                    else if (jednostkaDo == "m")
                    {
                        return (wartosc * 0.0254M); 
                    }
                    else if (jednostkaDo == "mila")
                    {
                        return (wartosc * 0.00001578M); 
                    }
                    else if (jednostkaDo == "kabel")
                    {
                        return (wartosc * 0.0001371M); 
                    }
                    else
                    {
                        return (wartosc * 0.00001371M); 
                    }
                    //break;
                case "stopa":
                    if (jednostkaDo == "mm")
                    {
                        return (wartosc * 304.8M);
                    }
                    else if (jednostkaDo == "cm")
                    {
                        return (wartosc * 30.48M); 
                    }
                    else if (jednostkaDo == "dm")
                    {
                        return (wartosc * 3.048M) * Inch; 
                    }
                    else if (jednostkaDo == "m")
                    {
                        return (wartosc * 0.3048M); 
                    }
                    else if (jednostkaDo == "mila")
                    {
                        return (wartosc * 0.00018939M); 
                    }
                    else if (jednostkaDo == "kabel")
                    {
                        return (wartosc * 608);
                    }
                    else
                    {
                        return (wartosc * 0.00016458M); 
                    }
                    //break;
                case "yard":
                    if (jednostkaDo == "mm")
                    {
                        return (wartosc * 914.4M); 
                    }
                    else if (jednostkaDo == "cm")
                    {
                        return (wartosc * 91.4M) * Ft; 
                    }
                    else if (jednostkaDo == "dm")
                    {
                        return (wartosc * 9.144M) * Inch; 
                    }
                    else if (jednostkaDo == "m")
                    {
                        return (wartosc * 0.9144M); 
                    }
                    else if (jednostkaDo == "mila")
                    {
                        return (wartosc * 0.00056818M);
                    }
                    else if (jednostkaDo == "kabel")
                    {
                        return (wartosc * 0.0049374M);
                    }
                    else
                    {
                        return (wartosc * 0.00049374M);
                    }
                    //break;
                case "mila":
                    if (jednostkaDo == "mm")
                    {
                        return (wartosc * 1609344); 
                    }
                    else if (jednostkaDo == "cm")
                    {
                        return (wartosc * 160934.4M) * Ft; 
                    }
                    else if (jednostkaDo == "dm")
                    {
                        return (wartosc * 16093.44M) * Inch; 
                    }
                    else if (jednostkaDo == "m")
                    {
                        return (wartosc * 1609.344M); 
                    }
                    else if (jednostkaDo == "kabel")
                    {
                        return (wartosc * 8.6897624M); 
                    }
                    else
                    {
                        return (wartosc * 0.86897624M); 
                    }
                   // break;
                case "kabel":
                    if (jednostkaDo == "mm")
                    {
                        return (wartosc * 185200);
                    }
                    else if (jednostkaDo == "cm")
                    {
                        return (wartosc * 18520) * Ft; 
                    }
                    else if (jednostkaDo == "dm")
                    {
                        return (wartosc * 1852) * Inch;
                    }
                    else if (jednostkaDo == "m")
                    {
                        return (wartosc * 185.2M); 
                    }
                    else if (jednostkaDo == "km")
                    {
                        return (wartosc * 1852); 
                    }
                    else if (jednostkaDo == "cal")
                    {
                        return (wartosc * 7291.3392M); 
                    }
                    else if (jednostkaDo == "stopa")
                    {
                        return (wartosc * 607.6116M);
                    }
                    else if (jednostkaDo == "yard")
                    {
                        return (wartosc * 202.5372M);
                    }
                    else
                    {
                        return (wartosc * 0.1151M);
                    }

                    //break;
                case "mila morska":
                    if (jednostkaDo == "mm")
                    {
                        return (wartosc * 1852000); 
                    }
                    else if (jednostkaDo == "cm")
                    {
                        return (wartosc * 185200) * Ft; 
                    }
                    else if (jednostkaDo == "dm")
                    {
                        return (wartosc * 18520) * Inch; 
                    }
                    else if (jednostkaDo == "m")
                    {
                        return (wartosc * 1852); 
                    }
                    else if (jednostkaDo == "km")
                    {
                        return (wartosc * 1.852M); 
                    }
                    else if (jednostkaDo == "cal")
                    {
                        return (wartosc * 72913.3848M); 
                    }
                    else if (jednostkaDo == "stopa")
                    {
                        return (wartosc * 6076.1155M); 
                    }
                    else if (jednostkaDo == "yard")
                    {
                        return (wartosc * 2025.3718M);
                    }
                    else
                    {
                        return (wartosc * 1.1508M); 
                    }
                    //break;
                    


            } 
            return wartosc;
        }
    }
}
