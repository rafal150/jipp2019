using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter
{
    class BazaNazw
    {
        
        List<string> kategorie = new List<string>();
        List<string> jednostkiTemp = new List<string>();
        List<string> jednostkiDlug = new List<string>();
        List<string> jednostkiMasa = new List<string>();
        public List<string> getKategoria()
        {
            kategorie.Clear();
            kategorie.Add("Temperatura");
            kategorie.Add("Dlugosc");
            kategorie.Add("Masa");
            return kategorie;
        }

        public List<string> getJednostkiTemp()
        {
            jednostkiTemp.Clear();
            jednostkiTemp.Add("Celcjusz");
            jednostkiTemp.Add("Farenheit");
            jednostkiTemp.Add("Kelvin");
            jednostkiTemp.Add("Rankine");
            return jednostkiTemp;
        }
        
        public List<string> getJednostkiDlug()
        {
            jednostkiDlug.Clear();
            jednostkiDlug.Add("mm");
            jednostkiDlug.Add("cm");
            jednostkiDlug.Add("dm");
            jednostkiDlug.Add("m");
            jednostkiDlug.Add("km");
            jednostkiDlug.Add("cal");
            jednostkiDlug.Add("stopa");
            jednostkiDlug.Add("jard");
            jednostkiDlug.Add("mila");
            jednostkiDlug.Add("kabel");
            jednostkiDlug.Add("mila morska");
            return jednostkiDlug;
        }

        public List<string> getJednostkiMasy()
        {
            jednostkiMasa.Clear();
            jednostkiMasa.Add("mg");
            jednostkiMasa.Add("g");
            jednostkiMasa.Add("dkg");
            jednostkiMasa.Add("kg");
            jednostkiMasa.Add("t");
            jednostkiMasa.Add("uncja");
            jednostkiMasa.Add("funt");
            jednostkiMasa.Add("karat");
            jednostkiMasa.Add("kwintal");
            return jednostkiMasa;
        }
        public List<string> wypelnienieJednostek(string nazwaKategorii)
        {
            List<string> jednostka =null;
            if (nazwaKategorii == kategorie.ElementAt(0))
            {
                jednostka = getJednostkiTemp();
            }
            else if (nazwaKategorii == kategorie.ElementAt(1))
            {
                jednostka = getJednostkiDlug();
            }
            else if (nazwaKategorii == kategorie.ElementAt(2))
            {
                jednostka = getJednostkiMasy();
            }
            return jednostka;
        }
    }

}
