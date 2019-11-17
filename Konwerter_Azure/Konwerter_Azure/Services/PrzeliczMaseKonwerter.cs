using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_Azure.Services
{
    public class PrzeliczMaseKonwerter : IConverter
    {
        public string Nazwa => "Masa";

        public List<string> Jednostki => new List<string>(new[] { "Kilogram", "Gram", "Miligram" });

        private string wynik;

        public decimal Przelicz(string idZ, string idNa, decimal input)
        {

            //if (ComboBoxZCzego.SelectedItem == ComboBoxNaCo.SelectedItem) wynik = input.ToString();

            if (idZ == "Kilogram" && idNa == "Kilogram")
                wynik = input.ToString();

            if (idZ == "Kilogram" && idNa == "Gram") // celsjusz na kelvin
                wynik = (input * decimal.Parse("1000")).ToString();
            if (idZ == "Kilogram" && idNa == "Miligram") // celsjusz na faren
                wynik = (input * decimal.Parse("1000000")).ToString();

            return decimal.Parse(wynik);
        }








        #region stare
        //public string ObliczTemperature(string idZ, string idNa, decimal input)
        //{
        //    if (ComboBoxZCzego.SelectedItem == ComboBoxNaCo.SelectedItem) wynikT = input.ToString();

        //    if (idZ == "C" && idNa == "C")
        //        wynikT = input.ToString();

        //    if (idZ == "C" && idNa == "K") // celsjusz na kelvin
        //        wynikT = (input + decimal.Parse("273,15")).ToString();
        //    if (idZ == "C" && idNa == "F") // celsjusz na faren
        //        wynikT = ((input * decimal.Parse("1,8")) + decimal.Parse("32,0")).ToString();
        //    TextBlockWynik.Text = ((double.Parse(TextBoxPodajWartosc.Text) * double.Parse("1,8")) + double.Parse("32,0")).ToString();
        //    if (idZ == "C" && idNa == "R") // celsjusz na ren
        //        wynikT = ((input + decimal.Parse("273,15")) * decimal.Parse("1,8")).ToString();

        //    if (idZ == "K" && idNa == "C") // kalvin na cel
        //        wynikT = (input - double.Parse("273,15")).ToString();
        //    if (idZ == "K" && idNa == "F") // kalvin na Farenheit
        //        wynikT = ((input * double.Parse("1,8")) - double.Parse("459,67")).ToString();
        //    if (idZ == "K" && idNa == "R") // kalvin na Rankie
        //        wynikT = (input * double.Parse("1,8")).ToString();


        //    if (idZ == "F" && idNa == "C") // Farenheit na celsjusz
        //        wynikT = ((input - double.Parse("32")) / double.Parse("1,8")).ToString();
        //    if (idZ == "F" && idNa == "K") // Farenheit na kelvin
        //        wynikT = ((input + double.Parse("459,67")) * (double.Parse("5") / double.Parse("9"))).ToString();
        //    if (idZ == "F" && idNa == "R") // Farenheit na Rankie
        //        wynikT = (input + double.Parse("459,67")).ToString();


        //    if (idZ == "R" && idNa == "C") // Rankie na celsjusz
        //        wynikT = ((input / double.Parse("1,8")) - double.Parse("273,15")).ToString();
        //    if (idZ == "R" && idNa == "K") // Rankie na kelvin
        //        wynikT = (input * (double.Parse("5") / double.Parse("9"))).ToString();
        //    if (idZ == "R" && idNa == "F") // Rankie na Farenheit
        //        wynikT = (input - double.Parse("459,67")).ToString();


        //    return wynikT;
        //}
        #endregion
    }
}
