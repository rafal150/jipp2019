using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Labs.Converters
{
    public class TempConv : IConverter
    {
        public string Name => "Temperatury";

        public List<string> Units => new List<string>(new[] { "Kelwin", "Farenheit", "Celsjusz", "Rankinee" });
        public double Convert(string from, string to, double value)
        {
            double constant = 0.555556;

            //MessageBox.Show(from);
            //MessageBox.Show(to);

            switch (from)
            {
                case "Celsjusz":

                    if (to == "Celsjusz")
                    {
                        //value = value;
                        if (value < -273)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Farenheit")
                    {
                        value = (value / constant) + 35;
                        if (value < -459)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Kelvin")
                    {
                        value = value + 273;
                        if (value < 0)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Rankine")
                    {
                        value = (value + 273) / constant;
                        if (value < 0)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    break;

                case "Farenheit":

                    if (to == "Celsjusz")
                    {
                        value = (value - 32) * constant;
                        if (value < -273)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Farenheit")
                    {
                        //value = value;
                        if (value < -459)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Kelvin")
                    {
                        value = (value + 460) * constant;
                        if (value < 0)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Rankine")
                    {
                        value = value + 460;
                        if (value < 0)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    break;

                case "Kelvin":

                    if (to == "Celsjusz")
                    {
                        value = value - 273;
                        if (value < -273)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Farenheit")
                    {
                        value = (value / constant) - 460;
                        if (value < -459)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Kelvin")
                    {
                       // value = value;
                        if (value < 0)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Rankine")
                    {
                        value = value / constant;
                        if (value < 0)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    break;

                case "Rankine":

                    if (to == "Celsjusz")
                    {
                        value = (value - 492) * constant;
                        if (value < -273)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Farenheit")
                    {
                        value = value - 460;
                        if (value < -459)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Kelvin")
                    {
                        value = value * constant;
                        if (value < 0)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Rankine")
                    {
                       // value = value;
                        if (value < 0)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    break;
            }

            return value;
        }
    }
}
