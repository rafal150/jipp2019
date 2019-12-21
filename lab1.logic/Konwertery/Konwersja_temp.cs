using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace lab1
{
    public partial class Konwersja_temp : IKonwersja
    {
        public string Nazwa => "Temperatury";

        public List<string> Jednostki => new List<string>(new[] { "Celsjusz", "Farenhait", "Kelvin", "Rankine" });
        public int Konwertuj(string z , string na , double wartosc) {
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
        
       
    }
}
