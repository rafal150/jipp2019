using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab1
{
    public partial class Konwersja_temp 
    {
        public Konwersja_temp()
        {
            
        }

        public int KonwersjaTemp(string z , string na , double wartosc) {
            int wynik;
            //referencja - celsjusz
            if (z == "Celsjusz") wartosc = wartosc;
            if (z == "Farenhait") wartosc = (wartosc-32.0)/1.8;
            if (z == "Kelvin") wartosc = wartosc - 273.15;
            if (z == "Rankine") wartosc = (wartosc) / 1.8 - 273.15;
            if (na == "Celsjusz") wartosc = wartosc;
            if (na == "Farenhait") wartosc = (wartosc) * 1.8 - 32;
            if (na == "Kelvin") wartosc = wartosc+273.15;
            if (na == "Renkine") wartosc = (wartosc+273.15)*1.8;
            wynik = (int)wartosc;
            return wynik;
        }
        
       public int KonwersjaMasa(string z, string na, double wartosc) {
            int wynik;
            //referencja kg
            if (z == "kg") wartosc = wartosc;
            if(z == "mg") wartosc = wartosc* 0.000001;
            if (z == "g") wartosc = wartosc * 0.001;
            if (z == "dkg") wartosc = wartosc*0.01;
            if (z == "T") wartosc = wartosc*1000;
            if (z == "uncja") wartosc = wartosc * 0.028349523;
            if (z == "funt") wartosc = wartosc * 0.45359237;
            if (z == "karat") wartosc = wartosc* 0.0002;
            if (z == "kwintal") wartosc = wartosc*100;
            if (na == "kg") wartosc = wartosc;
            if (na == "mg") wartosc = wartosc / 0.000001;
            if (na == "g") wartosc = wartosc / 0.001;
            if (na == "dkg") wartosc = wartosc / 0.01;
            if (na == "T") wartosc = wartosc / 1000;
            if (na == "uncja") wartosc = wartosc/ 0.028349523;
            if (na == "funt") wartosc = wartosc / 0.45359237;
            if (na == "karat") wartosc = wartosc / 0.0002;
            if (na == "kwintal") wartosc = wartosc / 100;
            wynik = (int)wartosc;
            return wynik;
              }
        //wrzucic do innej klasy
       public int KonwersjaDl(string z, string na, double wartosc) {
            int wynik;
            //referencja m
            if (z == "m") wartosc = wartosc;
            if (z == "mm") wartosc = wartosc* 0.001;
            if (z == "cmm") wartosc = wartosc*0.01;
            if (z == "dcm") wartosc = wartosc* 0.1;
            if (z == "km") wartosc = wartosc*1000;
            if (z == "cal") wartosc = wartosc* 0.0254;
            if (z == "stopa") wartosc = wartosc* 0.3048;
            if (z == "jard") wartosc = wartosc*0.9144;
            if (z == "mila") wartosc = wartosc* 1609.344;
            if (z == "kabel") wartosc = wartosc* 185.2;
            if (z == "mila morska") wartosc = wartosc* 1852;
            if (na == "m") wartosc = wartosc;
            if (na == "mm") wartosc = wartosc / 0.001;
            if (na == "cmm") wartosc = wartosc / 0.01;
            if (na == "dcm") wartosc = wartosc / 0.1;
            if (na == "km") wartosc = wartosc / 1000;
            if (na == "cal") wartosc = wartosc /0.0254;
            if (na == "stopa") wartosc = wartosc / 0.3048;
            if (na == "jard") wartosc = wartosc / 0.9144;
            if (na == "mila") wartosc = wartosc / 1609.344;
            if (na == "kabel") wartosc = wartosc / 185.2;
            if (na == "mila morska") wartosc = wartosc / 1852;
            wynik = (int)wartosc;
            return wynik;
        }

    }
}
