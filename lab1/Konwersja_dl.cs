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
    public partial class Konwersja_dl
    {
        public Konwersja_dl()
        {

        }

      
        public int KonwersjaDl(string z, string na, double wartosc)
        {
            int wynik;
            //referencja m
            if (z == "m") wartosc = wartosc;
            if (z == "mm") wartosc = wartosc * 0.001;
            if (z == "cmm") wartosc = wartosc * 0.01;
            if (z == "dcm") wartosc = wartosc * 0.1;
            if (z == "km") wartosc = wartosc * 1000;
            if (z == "cal") wartosc = wartosc * 0.0254;
            if (z == "stopa") wartosc = wartosc * 0.3048;
            if (z == "jard") wartosc = wartosc * 0.9144;
            if (z == "mila") wartosc = wartosc * 1609.344;
            if (z == "kabel") wartosc = wartosc * 185.2;
            if (z == "mila morska") wartosc = wartosc * 1852;
            if (na == "m") wartosc = wartosc;
            if (na == "mm") wartosc = wartosc / 0.001;
            if (na == "cmm") wartosc = wartosc / 0.01;
            if (na == "dcm") wartosc = wartosc / 0.1;
            if (na == "km") wartosc = wartosc / 1000;
            if (na == "cal") wartosc = wartosc / 0.0254;
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
