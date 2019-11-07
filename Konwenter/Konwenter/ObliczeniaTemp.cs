using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter
{
    class ObliczeniaTemp
    {           
        //BazaNazw bn = new BazaNazw();
        //double[,] macierzTemp = new double[4, 4];
        private List<double> listaNaCelcjusza = new List<double>();
        private List<double> listaZCelcjusza = new List<double>();

        //public double konwersjeTemp(string jednWejsc, string jednWyjsc, double wartoscWej)
        //{
        //    if (jednWejsc == bn.getJednostkiTemp().First())
        //    {
        //        if (jednWyjsc == bn.getJednostkiTemp().First())
        //        {
        //            wartoscWynik = wartoscWej;
        //        }
        //        else if (jednWyjsc == bn.getJednostkiTemp().ElementAt(1))
        //        {
        //            wartoscWynik = wartoscWej * 1.8 + 32;
        //        }
        //        else if (jednWyjsc == bn.getJednostkiTemp().ElementAt(2))
        //        {
        //            wartoscWynik = wartoscWej + 273.15;
        //        }
        //        else if (jednWyjsc == bn.getJednostkiTemp().ElementAt(3))
        //        {
        //            wartoscWynik = wartoscWej * 1.8 + 491.67;
        //        }
        //    }
        //    else if(jednWejsc==bn.getJednostkiTemp().ElementAt(1))
        //    {
        //        if (jednWyjsc == bn.getJednostkiTemp().First())
        //        {
        //            wartoscWynik = (wartoscWej - 32) / 1.8;
        //        }
        //        else if (jednWyjsc == bn.getJednostkiTemp().ElementAt(1))
        //        {
        //            wartoscWynik = wartoscWej;
        //        }
        //        else if (jednWyjsc == bn.getJednostkiTemp().ElementAt(2))
        //        {
        //            wartoscWynik = (wartoscWej - 32) / 1.8 + 273.15;
        //        }
        //        else if (jednWyjsc == bn.getJednostkiTemp().ElementAt(3))
        //        {
        //            wartoscWynik = (wartoscWej - 32) + 491.67;
        //        }
        //    }
        //    else if(jednWejsc==bn.getJednostkiTemp().ElementAt(2))
        //    {
        //        if (jednWyjsc == bn.getJednostkiTemp().First())
        //        {
        //            wartoscWynik = wartoscWej - 273.15;
        //        }
        //        else if (jednWyjsc == bn.getJednostkiTemp().ElementAt(1))
        //        {
        //            wartoscWynik = (wartoscWej - 32) / 1.8 - 273.15;
        //        }
        //        else if (jednWyjsc == bn.getJednostkiTemp().ElementAt(2))
        //        {
        //            wartoscWynik = wartoscWej;
        //        }
        //        else if (jednWyjsc == bn.getJednostkiTemp().ElementAt(3))
        //        {
        //            wartoscWynik = (wartoscWej - 273.15)*1.8 + 491.67;
        //        }
        //    }
        //    else if(jednWejsc==bn.getJednostkiTemp().ElementAt(3))
        //    {
        //        if (jednWyjsc == bn.getJednostkiTemp().First())
        //        {
        //            wartoscWynik = (wartoscWej - 491.67) / 1.8;
        //        }
        //        else if (jednWyjsc == bn.getJednostkiTemp().ElementAt(1))
        //        {
        //            wartoscWynik = (wartoscWej + 32) - 491.67;
        //        }
        //        else if (jednWyjsc == bn.getJednostkiTemp().ElementAt(2))
        //        {
        //            wartoscWynik = (wartoscWej - 491.67) / 1.8 + 273.15;
        //        }
        //        else if (jednWyjsc == bn.getJednostkiTemp().ElementAt(3))
        //        {
        //            wartoscWynik = wartoscWej;
        //        }
        //    }
        //    return wartoscWynik;
        //}
        //public double rownaniaTemp(double wartoscWej, int w, int k)
        //{
           
        //    double cc = wartoscWej;
        //    double cf = wartoscWej * 1.8 + 32;
        //    double ck = wartoscWej + 273.15;
        //    double cr = wartoscWej * 1.8 + 491.67;

        //    double fc = (wartoscWej - 32) / 1.8;
        //    double ff = wartoscWej;
        //    double fk = (wartoscWej - 32) / 1.8 + 273.15;
        //    double fr = (wartoscWej - 32) + 491.67;

        //    double kc = wartoscWej - 273.15;
        //    double kf = (wartoscWej - 32) / 1.8 - 273.15;
        //    double kk = wartoscWej;
        //    double kr = (wartoscWej - 273.15) * 1.8 + 491.67;

        //    double rc = (wartoscWej - 491.67) / 1.8;
        //    double rf = (wartoscWej + 32) - 491.67;
        //    double rk = (wartoscWej - 491.67) / 1.8 + 273.15;
        //    double rr = wartoscWej;

        //    macierzTemp[0, 0] = cc;
        //    macierzTemp[0, 1] = cf;
        //    macierzTemp[0, 2] = ck;
        //    macierzTemp[0, 3] = cr;

        //    macierzTemp[1, 0] = fc;
        //    macierzTemp[1, 1] = ff;
        //    macierzTemp[1, 2] = fk;
        //    macierzTemp[1, 3] = fr;

        //    macierzTemp[2, 0] = kc;
        //    macierzTemp[2, 1] = kf;
        //    macierzTemp[2, 2] = kk;
        //    macierzTemp[2, 3] = kr;

        //    macierzTemp[3, 0] = rc;
        //    macierzTemp[3, 1] = rf;
        //    macierzTemp[3, 2] = rk;
        //    macierzTemp[3, 3] = rr;

        //    return macierzTemp[w, k];
        //}
        public double naCelcjusza(double wartoscWej, int indexJednostkiWejsc)
        {
            listaNaCelcjusza.Clear();
            listaNaCelcjusza.Add(wartoscWej); //celcjusz na celcjusz
            listaNaCelcjusza.Add((wartoscWej-32)/1.8); //faren na celcjusz
            listaNaCelcjusza.Add(wartoscWej - 273.15); //kelvin na celcjusz
            listaNaCelcjusza.Add((wartoscWej - 491.67) / 1.8); //rankin na celcjusz
            return listaNaCelcjusza.ElementAt(indexJednostkiWejsc);
        }
        public double zCelcjusza(double wartoscWej, int indexJednostkiWejsc, int indexJednostkiWyjsc)
        {
            double wartoscTemp = 0;
            wartoscTemp = naCelcjusza(wartoscWej, indexJednostkiWejsc);
            listaZCelcjusza.Clear();
            listaZCelcjusza.Add(wartoscTemp);
            listaZCelcjusza.Add(wartoscTemp * 1.8 + 32);
            listaZCelcjusza.Add(wartoscTemp + 273.15);
            listaZCelcjusza.Add(wartoscTemp * 1.8 + 491.67);
            return listaZCelcjusza.ElementAt(indexJednostkiWyjsc);
        }
       
    }
}
