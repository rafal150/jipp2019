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

using Laborki.Classes;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace Laborki.Classes
{
    class ConvertClass
    {

        public double convertTemperature(string from, string to)
        {
            double value = 0;
            double constant = 0.555556;

            switch (from)
            {
                case "Celsjusz":

                    if (to == "Celsjusz")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                        if (value < -273)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Farenheit")
                    {
                        value = ((double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / constant) + 35;
                        if (value < -459)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Kelvin")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) + 273;
                        if (value < 0)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Rankine")
                    {
                        value = ((double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) + 273) / constant;
                        if (value < 0)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    break;

                case "Farenheit":

                    if (to == "Celsjusz")
                    {
                        value = ((double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) - 32) * constant;
                        if (value < -273)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Farenheit")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                        if (value < -459)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Kelvin")
                    {
                        value = ((double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) + 460) * constant;
                        if (value < 0)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Rankine")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) + 460;
                        if (value < 0)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    break;

                case "Kelvin":

                    if (to == "Celsjusz")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) - 273;
                        if (value < -273)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Farenheit")
                    {
                        value = ((double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / constant) - 460;
                        if (value < -459)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Kelvin")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                        if (value < 0)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Rankine")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / constant;
                        if (value < 0)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    break;

                case "Rankine":

                    if (to == "Celsjusz")
                    {
                        value = ((double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) - 492) * constant;
                        if (value < -273)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Farenheit")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) - 460;
                        if (value < -459)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Kelvin")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * constant;
                        if (value < 0)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    else if (to == "Rankine")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                        if (value < 0)
                        {
                            value = 0; // Temperatura nie może być niższa niż 0 kelvinów
                        }
                    }
                    break;

            }

            return value;
        }

        public double convertMMetric(string from, string to)
        {
            double value = 0;


            switch (from)
            {
                case "mm":

                    if (to == "mm")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }
                    else if (to == "cm")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 10;
                    }
                    else if (to == "dcm")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 100;
                    }
                    else if (to == "m")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 10000;
                    }
                    else if (to == "km")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 1000000;
                    }

                    break;

                case "cm":

                    if (to == "mm")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 10;
                    }
                    else if (to == "cm")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }
                    else if (to == "dcm")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 10;
                    }
                    else if (to == "m")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 100;
                    }
                    else if (to == "km")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 100000;
                    }

                    break;

                case "dcm":

                    if (to == "mm")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 100;
                    }
                    else if (to == "cm")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 10;
                    }
                    else if (to == "dcm")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }
                    else if (to == "m")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 10;
                    }
                    else if (to == "km")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 10000;
                    }
                    break;

                case "m":

                    if (to == "mm")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 1000;
                    }
                    else if (to == "cm")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 100;
                    }
                    else if (to == "dcm")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 10;
                    }
                    else if (to == "m")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }
                    else if (to == "km")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 1000;
                    }

                    break;

                case "km":

                    if (to == "mm")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 1000000;
                    }
                    else if (to == "cm")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 100000;
                    }
                    else if (to == "dcm")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 10000;
                    }
                    else if (to == "m")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 1000;
                    }
                    else if (to == "km")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }
                    break;

            }


            return value;
        }

        public double convertMEng(string from, string to)
        {
            double value = 0;


            switch (from)
            {
                case "cal":

                    if (to == "cal")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }
                    else if (to == "stopa")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 12;
                    }
                    else if (to == "jard")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 36;
                    }
                    else if (to == "mila")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 63360;
                    }

                    break;

                case "stopa":

                    if (to == "cal")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 12;
                    }
                    else if (to == "stopa")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }
                    else if (to == "jard")
                    {
                        value = (double)Convert.ToDouble(Laborki.MainWindow.AppWindow.TextBoxFrom.Text) / 3;
                    }
                    else if (to == "mila")
                    {
                        value = (double)Convert.ToDouble(Laborki.MainWindow.AppWindow.TextBoxFrom.Text) / 5280;
                    }

                    break;

                case "jard":

                    if (to == "cal")
                    {
                        value = (double)Convert.ToDouble(Laborki.MainWindow.AppWindow.TextBoxFrom.Text) * 36;
                    }
                    else if (to == "stopa")
                    {
                        value = (double)Convert.ToDouble(Laborki.MainWindow.AppWindow.TextBoxFrom.Text) * 3;
                    }
                    else if (to == "jard")
                    {
                        value = (double)Convert.ToDouble(Laborki.MainWindow.AppWindow.TextBoxFrom.Text);
                    }
                    else if (to == "mila")
                    {
                        value = (double)Convert.ToDouble(Laborki.MainWindow.AppWindow.TextBoxFrom.Text) / 1760;
                    }

                    break;

                case "mila":

                    if (to == "cal")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 63360;
                    }
                    else if (to == "stopa")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 5280;
                    }
                    else if (to == "jard")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 1760;
                    }
                    else if (to == "mila")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }

                    break;

            }


            return value;
        }

        public double convertMSea(string from, string to)
        {
            double value = 0;


            switch (from)
            {
                case "kabel":

                    if (to == "kabel")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }
                    else if (to == "mila morska")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 10;
                    }

                    break;

                case "mila morska":

                    if (to == "kabel")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 10;
                    }
                    else if (to == "mila morska")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }

                    break;
            }


            return value;
        }

        public double convertSMetric(string from, string to)
        {
            double value = 0;


            switch (from)
            {
                case "mg":

                    if (to == "mg")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }
                    else if (to == "g")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 1000;
                    }
                    else if (to == "dkg")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 10000;
                    }
                    else if (to == "kg")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 1000000;
                    }
                    else if (to == "T")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 1000000000;
                    }

                    break;

                case "g":

                    if (to == "mg")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 1000;
                    }
                    else if (to == "g")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }
                    else if (to == "dkg")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 10;
                    }
                    else if (to == "kg")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 1000;
                    }
                    else if (to == "T")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 100000;
                    }

                    break;

                case "dkg":

                    if (to == "mg")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 10000;
                    }
                    else if (to == "g")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 10;
                    }
                    else if (to == "dkg")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }
                    else if (to == "kg")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 10;
                    }
                    else if (to == "T")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 10000;
                    }

                    break;

                case "kg":

                    if (to == "mg")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 1000000;
                    }
                    else if (to == "g")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 1000;
                    }
                    else if (to == "dkg")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 100;
                    }
                    else if (to == "kg")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }
                    else if (to == "T")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 1000;
                    }

                    break;

                case "T":

                    if (to == "mg")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 1000000000;
                    }
                    else if (to == "g")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 1000000;
                    }
                    else if (to == "dkg")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 100000;
                    }
                    else if (to == "kg")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 1000;
                    }
                    else if (to == "T")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }

                    break;

            }


            return value;
        }

        public double convertSEng(string from, string to)
        {
            double value = 0;


            switch (from)
            {
                case "uncja":

                    if (to == "uncja")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }
                    else if (to == "funt")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 16;
                    }

                    break;

                case "funt":

                    if (to == "uncja")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 16;
                    }
                    else if (to == "funt")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }

                    break;
            }


            return value;
        }

        public double convertSOther(string from, string to)
        {
            double value = 0;


            switch (from)
            {
                case "karat":

                    if (to == "karat")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }
                    else if (to == "kwintal")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) / 500000;
                    }

                    break;

                case "kwintal":

                    if (to == "karat")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text) * 500000;
                    }
                    else if (to == "kwintal")
                    {
                        value = (double)Convert.ToDouble(MainWindow.AppWindow.TextBoxFrom.Text);
                    }

                    break;
            }


            return value;
        }
    }
}
