using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_Azure.Services
{
    public class PrzeliczTemperatureKonwerter : IConverter
    {
        public string Nazwa => "Temperatura";

        public List<string> Jednostki => new List<string>(new[] { "Celsjusz", "F", "K", "R" });

        private string wynik;

        public decimal Przelicz(string idZ, string idNa, decimal input)
        {
            
            //if (ComboBoxZCzego.SelectedItem == ComboBoxNaCo.SelectedItem) wynik = input.ToString();

            if (idZ == "Celsjusz" && idNa == "Celsjusz")
                wynik = input.ToString();

            if (idZ == "Celsjusz" && idNa == "K") // celsjusz na kelvin
                wynik = (input + decimal.Parse("273,15")).ToString();
            if (idZ == "Celsjusz" && idNa == "F") // celsjusz na faren
                wynik = ((input * decimal.Parse("1,8")) + decimal.Parse("32,0")).ToString();
            //TextBlockWynik.Text = ((double.Parse(TextBoxPodajWartosc.Text) * double.Parse("1,8")) + double.Parse("32,0")).ToString();
            if (idZ == "Celsjusz" && idNa == "R") // celsjusz na ren
                wynik = ((input + decimal.Parse("273,15")) * decimal.Parse("1,8")).ToString();

            return decimal.Parse(wynik);
        }



        #region stare
        //private string wynikT;

        //public string ObliczTemperature(string idZ, string idNa, decimal input)
        //{
        //    //if (ComboBoxZCzego.SelectedItem == ComboBoxNaCo.SelectedItem) wynikT = input.ToString();

        //    if (idZ == "C" && idNa == "C")
        //        wynikT = input.ToString();

        //    if (idZ == "C" && idNa == "K") // celsjusz na kelvin
        //        wynikT = (input + decimal.Parse("273,15")).ToString();
        //    if (idZ == "C" && idNa == "F") // celsjusz na faren
        //        wynikT = ((input * decimal.Parse("1,8")) + decimal.Parse("32,0")).ToString();
        //    //TextBlockWynik.Text = ((double.Parse(TextBoxPodajWartosc.Text) * double.Parse("1,8")) + double.Parse("32,0")).ToString();
        //    if (idZ == "C" && idNa == "R") // celsjusz na ren
        //        wynikT = ((input + decimal.Parse("273,15")) * decimal.Parse("1,8")).ToString();

        //    return wynikT;
        //}
        #endregion
    }
}
