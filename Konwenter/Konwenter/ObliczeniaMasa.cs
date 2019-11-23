using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter
{
    class ObliczeniaMasa
    {       
        double[,] macierzMasa = new double[9, 9];
        private List<double> listaNaMiligram = new List<double>();
        private List<double> listaZMiligram = new List<double>();

        //public double rownaniaMasa(double wartoscWej, int w, int k)
        //{
        //    double mgmg = wartoscWej;
        //    double mgg = wartoscWej * 0.001;
        //    double mgdg = wartoscWej * 0.0001;
        //    double mgkg = wartoscWej * 0.000001;
        //    double mgt = wartoscWej * 0.000000001;
        //    double mgun = wartoscWej * 0.000035274;
        //    double mgfu = wartoscWej * 0.000002246;
        //    double mgka = wartoscWej * 0.005;
        //    double mgkw = wartoscWej * 0.0001;

        //    macierzMasa[0, 0] = mgmg;
        //    macierzMasa[0, 1] = mgg;
        //    macierzMasa[0, 2] = mgdg;
        //    macierzMasa[0, 3] = mgkg;
        //    macierzMasa[0, 4] = mgt;
        //    macierzMasa[0, 5] = mgun;
        //    macierzMasa[0, 6] = mgfu;
        //    macierzMasa[0, 7] = mgka;
        //    macierzMasa[0, 8] = mgkw;

        //    return macierzMasa[w, k];
        //}
        public double naMiligramy (double wartoscWej, int indexJednostkiWejsc)
        {
            listaNaMiligram.Clear();

            listaNaMiligram.Add(wartoscWej);
            listaNaMiligram.Add(wartoscWej *1000);
            listaNaMiligram.Add(wartoscWej *10000);
            listaNaMiligram.Add(wartoscWej *1000000);
            listaNaMiligram.Add(wartoscWej *1000000000);
            listaNaMiligram.Add(wartoscWej * 28349.5231);
            listaNaMiligram.Add(wartoscWej * 453592.37);
            listaNaMiligram.Add(wartoscWej *200);
            listaNaMiligram.Add(wartoscWej * 100000000);
            return listaNaMiligram.ElementAt(indexJednostkiWejsc);
        }
        public double zMiligramy(double wartoscWej, int indexJednostkiWejsc, int indexJednostkiWyjsc)
        {
            double wartoscTemp = 0;
            wartoscTemp = naMiligramy(wartoscWej, indexJednostkiWejsc);
            listaZMiligram.Clear();

            listaZMiligram.Add(wartoscTemp);
            listaZMiligram.Add(wartoscTemp * 0.001);
            listaZMiligram.Add(wartoscTemp * 0.0001);
            listaZMiligram.Add(wartoscTemp * 0.000001);
            listaZMiligram.Add(wartoscTemp * 0.000000001);
            listaZMiligram.Add(wartoscTemp * 0.000035274);
            listaZMiligram.Add(wartoscTemp * 0.000002246);
            listaZMiligram.Add(wartoscTemp * 0.005);
            listaZMiligram.Add(wartoscTemp * 0.0001);
            return listaZMiligram.ElementAt(indexJednostkiWyjsc);


        }
    }
}
