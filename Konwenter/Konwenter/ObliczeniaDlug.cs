using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter
{
    class ObliczeniaDlug
    {       
        //double[,] macierzDlug = new double[11, 11];
        private List<double> listaNaMilimetry = new List<double>();
        private List<double> listaZMilimetry = new List<double>();

        //public double rownaniaDlug(double wartoscWej, int w, int k)
        //{
        //    double mmmm = wartoscWej;
        //    double mmcm = wartoscWej * 0.1;
        //    double mmdm = wartoscWej * 0.01;
        //    double mmm = wartoscWej * 0.0001;
        //    double mmkm = wartoscWej * 0.0000001;
        //    double mmca = wartoscWej * 0.039370;
        //    double mmst = wartoscWej * 0.0032808;
        //    double mmja = wartoscWej * 0.00010936;
        //    double mmmi = wartoscWej * 0.00000002137;
        //    double mmka = wartoscWej * 0.000005399;
        //    double mmmmor = wartoscWej * 0.0000005399;

        //    macierzDlug[0, 0] = mmmm;
        //    macierzDlug[0, 1] = mmcm;
        //    macierzDlug[0, 2] = mmdm;
        //    macierzDlug[0, 3] = mmm;
        //    macierzDlug[0, 4] = mmkm;
        //    macierzDlug[0, 5] = mmca;
        //    macierzDlug[0, 6] = mmst;
        //    macierzDlug[0, 7] = mmja;
        //    macierzDlug[0, 8] = mmmi;
        //    macierzDlug[0, 9] = mmka;
        //    macierzDlug[0, 10] = mmmmor;

        //    return macierzDlug[w, k];


        //}
        public double naMilimetry(double wartoscWej, int indexJednostkiWejsc)
        {
            listaNaMilimetry.Clear();
            listaNaMilimetry.Add(wartoscWej);
            listaNaMilimetry.Add(wartoscWej * 10);
            listaNaMilimetry.Add(wartoscWej * 100);
            listaNaMilimetry.Add(wartoscWej * 1000);
            listaNaMilimetry.Add(wartoscWej * 100000);
            listaNaMilimetry.Add(wartoscWej * 25.4);
            listaNaMilimetry.Add(wartoscWej * 304.8);
            listaNaMilimetry.Add(wartoscWej * 914.4);
            listaNaMilimetry.Add(wartoscWej * 1609344);
            listaNaMilimetry.Add(wartoscWej * 185200);
            listaNaMilimetry.Add(wartoscWej * 1852000);
            return listaNaMilimetry.ElementAt(indexJednostkiWejsc);
        }
        public double zMilimetry(double wartoscWej, int indexJednostkiWejsc, int indexJednostkiWyjsc)
        {
            double wartoscTemp = 0;
            wartoscTemp = naMilimetry(wartoscWej, indexJednostkiWejsc);
            listaZMilimetry.Clear();
            listaZMilimetry.Add(wartoscTemp);
            listaZMilimetry.Add(wartoscTemp * 0.1);
            listaZMilimetry.Add(wartoscTemp * 0.01);
            listaZMilimetry.Add(wartoscTemp * 0.0001);
            listaZMilimetry.Add(wartoscTemp * 0.0000001);
            listaZMilimetry.Add(wartoscTemp * 0.0393700787);
            listaZMilimetry.Add(wartoscTemp * 0.0032808);
            listaZMilimetry.Add(wartoscTemp * 0.00010936);
            listaZMilimetry.Add(wartoscTemp * 0.00000002137);
            listaZMilimetry.Add(wartoscTemp * 0.000005399);
            listaZMilimetry.Add(wartoscTemp * 0.0000005399);
            return listaZMilimetry.ElementAt(indexJednostkiWyjsc);
        }
    }
}
