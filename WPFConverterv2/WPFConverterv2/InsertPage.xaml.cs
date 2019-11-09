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
using System.Windows.Shapes;
using System.Timers;


namespace WPFConverterv2
{
    /// <summary>
    /// Logika interakcji dla klasy InsertPage.xaml
    /// </summary>
    /// 
    public partial class InsertPage : Window
    {

        public void ToTemperature()
        {
            if(this.UnitFromBox.Text == "C" && this.UnitToBox.Text == "F")        //CELCJUSZ NA FAHRENHEIT
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1.8 + 32).ToString();
                this.TypeBox.Text = "Temperatura";
            }

            if (this.UnitFromBox.Text == "K" && this.UnitToBox.Text == "F")        //KELWIN NA FAHRENHEIT
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1.8 - 459).ToString();
                this.TypeBox.Text = "Temperatura";
            }

            if (this.UnitFromBox.Text == "R" && this.UnitToBox.Text == "F")        //RANKINE NA FAHRENHEIT
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) - 459).ToString();
                this.TypeBox.Text = "Temperatura";
            }

            if (this.UnitFromBox.Text == "F" && this.UnitToBox.Text == "F")        //FARENHEIT NA FAHRENHEIT
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text)* 1).ToString();
                this.TypeBox.Text = "Temperatura";
            }
                                            //FAHRENHEIT NA CELCJUSZE

            if (this.UnitFromBox.Text == "F" && this.UnitToBox.Text == "C")        
            {
                this.ConvertedValueBox.Text = 
                ((int.Parse(this.RawValueBox.Text) - 32) / 1.8 ).ToString();
                this.TypeBox.Text = "Temperatura";
            }

            if (this.UnitFromBox.Text == "F" && this.UnitToBox.Text == "K")        //FAHRENHEIT NA KELWINY            
            {
                this.ConvertedValueBox.Text =
                ((int.Parse(this.RawValueBox.Text) + 459) * 5 / 9).ToString();
                this.TypeBox.Text = "Temperatura";
            }

            if (this.UnitFromBox.Text == "F" && this.UnitToBox.Text == "R")         //FAHRENHEIT NA RANKINE    
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) + 459).ToString();
                this.TypeBox.Text = "Temperatura";
            }

                                            //CELCJUSZ NA KELWINY
             if(this.UnitFromBox.Text == "C" && this.UnitToBox.Text == "K")        
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) + 273.15).ToString();
                this.TypeBox.Text = "Temperatura";
            }

            if (this.UnitFromBox.Text == "C" && this.UnitToBox.Text == "R")        //CELCJUSZ NA RANKINE
            {
                this.ConvertedValueBox.Text =
                ((int.Parse(this.RawValueBox.Text) + 273.15)*1.8).ToString();
                this.TypeBox.Text = "Temperatura";
            }

            if (this.UnitFromBox.Text == "C" && this.UnitToBox.Text == "C")        //CELCJUSZ NA CELCJUSZ
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1).ToString();
                this.TypeBox.Text = "Temperatura";
            }

                                            //RANKINE NA CELCJUSZE
            if (this.UnitFromBox.Text == "R" && this.UnitToBox.Text == "C")
            {
                this.ConvertedValueBox.Text =
                ((int.Parse(this.RawValueBox.Text) -491)/1.8).ToString();
                this.TypeBox.Text = "Temperatura";
            }

            if (this.UnitFromBox.Text == "R" && this.UnitToBox.Text == "K")         //RANKINE NA KELWINY
            {
                this.ConvertedValueBox.Text =
                (((int.Parse(this.RawValueBox.Text) -491)/1.8)+273).ToString();
                this.TypeBox.Text = "Temperatura";
            }

            if (this.UnitFromBox.Text == "R" && this.UnitToBox.Text == "R")         //RANKINE NA RANKINE
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1).ToString();
                this.TypeBox.Text = "Temperatura";
            }

        }

        public void ToLength()

        {                   //MILIMETRY NA INNE JEDNOSTKI
            if (this.UnitFromBox.Text == "mm" && this.UnitToBox.Text == "mm")        //mm na mm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mm" && this.UnitToBox.Text == "cm")        //mm na cm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mm" && this.UnitToBox.Text == "dcm")        //mm na dcm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.01 ).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mm" && this.UnitToBox.Text == "m")        //mm na m
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.001).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mm" && this.UnitToBox.Text == "km")        //mm na km
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.000001).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mm" && this.UnitToBox.Text == "cal")        //mm na cal
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.039370).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mm" && this.UnitToBox.Text == "stopy")        //mm na stopy
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0032808).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mm" && this.UnitToBox.Text == "jard")        //mm na jard
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.001093).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mm" && this.UnitToBox.Text == "mila")        //mm na mila
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0000006214).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mm" && this.UnitToBox.Text == "mila morska")        //mm na mila morska
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.00000054).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mm" && this.UnitToBox.Text == "kabel")        //mm na KABEL
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.00000054 * 0.1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

                            //CENTYMETRY NA INNE JEDNOSTKI
            if (this.UnitFromBox.Text == "cm" && this.UnitToBox.Text == "mm")        //cm na mm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 10).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cm" && this.UnitToBox.Text == "cm")        //cm na cm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cm" && this.UnitToBox.Text == "dcm")        //cm na dcm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.1 ).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cm" && this.UnitToBox.Text == "m")        //cm na m
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.01).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cm" && this.UnitToBox.Text == "km")        //cm na km
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.00001).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cm" && this.UnitToBox.Text == "cal")        //cm na cal
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.39370).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cm" && this.UnitToBox.Text == "stopy")        //cm na stopy
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.032808).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cm" && this.UnitToBox.Text == "jard")        //cm na jard
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.01093).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cm" && this.UnitToBox.Text == "mila")        //cm na mila
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.000006214).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cm" && this.UnitToBox.Text == "mila morska")        //cm na mila morska
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0000054).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cm" && this.UnitToBox.Text == "kabel")        //cm na KABEL
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0000054 * 0.1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

                            //DECYMETRY NA INNE JEDNOSTKI
            if (this.UnitFromBox.Text == "dcm" && this.UnitToBox.Text == "mm")        //dcm na mm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 100).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "dcm" && this.UnitToBox.Text == "cm")        //dcm na cm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 10).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "dcm" && this.UnitToBox.Text == "dcm")        //dcm na dcm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "dcm" && this.UnitToBox.Text == "m")        //dcm na m
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "dcm" && this.UnitToBox.Text == "km")        //dcm na km
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0001).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "dcm" && this.UnitToBox.Text == "cal")        //dcm na cal
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 3.9370).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "dcm" && this.UnitToBox.Text == "stopy")        //dcm na stopy
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.32808).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "dcm" && this.UnitToBox.Text == "jard")        //dcm na jard
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.1093).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "dcm" && this.UnitToBox.Text == "mila")        //dcm na mila
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.00006214).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "dcm" && this.UnitToBox.Text == "mila morska")        //dcm na mila morska
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.000054).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "dcm" && this.UnitToBox.Text == "kabel")        //dcm na KABEL
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.000054 * 0.1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

                                //METRY NA INNE JEDNOSTKI
            if (this.UnitFromBox.Text == "m" && this.UnitToBox.Text == "mm")        //m na mm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1000).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "m" && this.UnitToBox.Text == "cm")        //m na cm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 100).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "m" && this.UnitToBox.Text == "dcm")        //m na dcm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 10).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "m" && this.UnitToBox.Text == "m")        //m na m
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "m" && this.UnitToBox.Text == "km")        //m na km
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.001).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "m" && this.UnitToBox.Text == "cal")        //m na cal
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 39.370).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "m" && this.UnitToBox.Text == "stopy")        //m na stopy
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 3.2808).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "m" && this.UnitToBox.Text == "jard")        //m na jard
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1.093).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "m" && this.UnitToBox.Text == "mila")        //m na mila
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0006214).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "m" && this.UnitToBox.Text == "mila morska")        //m na mila morska
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.00054).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "m" && this.UnitToBox.Text == "kabel")        //m na KABEL
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.00054 * 0.1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

                                //KILOMETRY NA INNE JEDNOSTKI
            if (this.UnitFromBox.Text == "km" && this.UnitToBox.Text == "mm")        //km na mm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1000000).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "km" && this.UnitToBox.Text == "cm")        //km na cm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 100000).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "km" && this.UnitToBox.Text == "dcm")        //km na cm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 10000).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "km" && this.UnitToBox.Text == "m")        //km na m
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1000).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "km" && this.UnitToBox.Text == "km")        //km na km
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "km" && this.UnitToBox.Text == "cal")        //km na cal
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 39370).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "km" && this.UnitToBox.Text == "stopy")        //km na stopy
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 3280.8).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "km" && this.UnitToBox.Text == "jard")        //km na jard
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1093).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "km" && this.UnitToBox.Text == "mila")        //km na mila
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.6214).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "km" && this.UnitToBox.Text == "mila morska")        //km na mila morska
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.54).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "km" && this.UnitToBox.Text == "kabel")        //km na KABEL
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.54 * 0.1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

                                    //CAL NA INNE JEDNOSTKI
            if (this.UnitFromBox.Text == "cal" && this.UnitToBox.Text == "mm")        //cal na mm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 25.4).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cal" && this.UnitToBox.Text == "cm")        //cal na cm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 2.54).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cal" && this.UnitToBox.Text == "dcm")        //cal na dcm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.254).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cal" && this.UnitToBox.Text == "m")        //cal na m
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0254).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cal" && this.UnitToBox.Text == "km")        //cal na km
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0000254).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cal" && this.UnitToBox.Text == "cal")        //cal na cal
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cal" && this.UnitToBox.Text == "stopy")        //cal na stopy
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.833).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cal" && this.UnitToBox.Text == "jard")        //cal na jard
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0277).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cal" && this.UnitToBox.Text == "mila")        //cal na mila
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.00001578).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cal" && this.UnitToBox.Text == "mila morska")        //cal na mila morska
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0000137).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "cal" && this.UnitToBox.Text == "kabel")        //cal na KABEL
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0000137 * 0.1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

                                         //STOPY NA INNE JEDNOSTKI
            if (this.UnitFromBox.Text == "stopy" && this.UnitToBox.Text == "mm")        //stopy na mm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 304.8).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "stopy" && this.UnitToBox.Text == "cm")        //stopy na cm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 30.48).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "stopy" && this.UnitToBox.Text == "dcm")        //stopy na dcm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 3.048).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "stopy" && this.UnitToBox.Text == "m")        //stopy na m
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.3048).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "stopy" && this.UnitToBox.Text == "km")        //stopy na km
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0003048).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "stopy" && this.UnitToBox.Text == "cal")        //stopy na cal
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 12).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "stopy" && this.UnitToBox.Text == "stopy")        //stopy na stopy
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "stopy" && this.UnitToBox.Text == "jard")        //stopy na jard
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.3333).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "stopy" && this.UnitToBox.Text == "mila")        //stopy na mila
            {    
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.00018939).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "stopy" && this.UnitToBox.Text == "mila morska")        //stopy na mila morska
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.000164).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "stopy" && this.UnitToBox.Text == "kabel")        //stopy na KABEL
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.000164 * 0.1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

                                            //JARDY NA INNE JEDNOSTKI
            if (this.UnitFromBox.Text == "jard" && this.UnitToBox.Text == "mm")        //jardy na mm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 914.4).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "jard" && this.UnitToBox.Text == "cm")        //jardy na cm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 91.44).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "jard" && this.UnitToBox.Text == "dcm")        //jardy na dcm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 9.144).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "jard" && this.UnitToBox.Text == "m")        //jardy na m
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.9144).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "jard" && this.UnitToBox.Text == "km")        //jardy na km
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0009144).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "jard" && this.UnitToBox.Text == "cal")        //jardy na cal
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 36).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "jard" && this.UnitToBox.Text == "stopy")        //jardy na stopy
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 3).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "jard" && this.UnitToBox.Text == "jard")        //jardy na jard
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "jard" && this.UnitToBox.Text == "mila")        //jardy na mila
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0005681).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "jard" && this.UnitToBox.Text == "mila morska")        //jardy na mila morska
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0004937).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "jard" && this.UnitToBox.Text == "kabel")        //jardy na KABEL
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0004937 * 0.1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

                                //Mile NA INNE JEDNOSTKI
            if (this.UnitFromBox.Text == "mila" && this.UnitToBox.Text == "mm")        //mile na mm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1609344).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila" && this.UnitToBox.Text == "cm")        //mile na cm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 160934.4).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila" && this.UnitToBox.Text == "dcm")        //mile na dcm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 16093.44).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila" && this.UnitToBox.Text == "m")        //mile na m
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1609.344).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila" && this.UnitToBox.Text == "km")        //mile na km
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1.609344).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila" && this.UnitToBox.Text == "cal")        //mile na cal
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 63360).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila" && this.UnitToBox.Text == "stopy")        //mile na stopy
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 5280).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila" && this.UnitToBox.Text == "jard")        //mile na jard
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1760).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila" && this.UnitToBox.Text == "mila")        //mile na mile
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila" && this.UnitToBox.Text == "mila morska")        //mile na mila morska
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.8689).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila" && this.UnitToBox.Text == "kabel")        //mile na KABEL
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.8689 * 0.1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

                            //KABEL NA INNE JEDNOSTKI
            if (this.UnitFromBox.Text == "kabel" && this.UnitToBox.Text == "mm")        //kabel na mm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 185200).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "kabel" && this.UnitToBox.Text == "cm")        //kabel na cm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 18520).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "kabel" && this.UnitToBox.Text == "dcm")        //kabel na dcm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 18520).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "kabel" && this.UnitToBox.Text == "m")        //kabel na m
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1852).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "kabel" && this.UnitToBox.Text == "km")        //kabel na km
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1.852).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "kabel" && this.UnitToBox.Text == "cal")        //kabel na cal
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 7291).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "kabel" && this.UnitToBox.Text == "stopy")        //kabel na stopy
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 607.6).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "kabel" && this.UnitToBox.Text == "jard")        //kabel na jard
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 202.5).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "kabel" && this.UnitToBox.Text == "mila")        //kabel na mile
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.115).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "kabel" && this.UnitToBox.Text == "mila morska")        //kabel na mila morska
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "kabel" && this.UnitToBox.Text == "kabel")        //kabel na KABEL
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

                                //Mile NA INNE JEDNOSTKI
            if (this.UnitFromBox.Text == "mila morska" && this.UnitToBox.Text == "mm")        //mile na mm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1852000).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila morska" && this.UnitToBox.Text == "cm")        //mila morska na cm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 185200).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila morska" && this.UnitToBox.Text == "dcm")        //mila morska na dcm
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 18520).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila morska" && this.UnitToBox.Text == "m")        //mila morska na m
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1852).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila morska" && this.UnitToBox.Text == "km")        //mila morska na km
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1.852).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila morska" && this.UnitToBox.Text == "cal")        //mila morska na cal
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 72913.4).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila morska" && this.UnitToBox.Text == "stopy")        //mila morska na stopy
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 6076).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila morska" && this.UnitToBox.Text == "jard")        //mila morska na jard
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 2025.4).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila morska" && this.UnitToBox.Text == "mila")        //mila morska na mile
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1.15).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila morska" && this.UnitToBox.Text == "mila morska")        //mila morska na mila morska
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1).ToString();
                this.TypeBox.Text = "Dlugosc";
            }

            if (this.UnitFromBox.Text == "mila morska" && this.UnitToBox.Text == "kabel")        //mila morska na KABEL
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 10).ToString();
                this.TypeBox.Text = "Dlugosc";
            }
        }

        public void ToMass()
        {
                                //MILIGRAMY NA INNE JEDNOSTKI
            if (this.UnitFromBox.Text == "mg" && this.UnitToBox.Text == "mg")        //mg na mg
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "mg" && this.UnitToBox.Text == "g")        //mg na g
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.001).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "mg" && this.UnitToBox.Text == "dkg")        //mg na dkg
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0001).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "mg" && this.UnitToBox.Text == "kg")        //mg na kg
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.000001).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "mg" && this.UnitToBox.Text == "T")        //mg na tone
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.000000001).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "mg" && this.UnitToBox.Text == "uncja")        //mg na uncje
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.000035274).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "mg" && this.UnitToBox.Text == "funt")        //mg na funt
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0000022).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "mg" && this.UnitToBox.Text == "karat")        //mg na karaty
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.00488).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "mg" && this.UnitToBox.Text == "kwintal")        //mg na kwintale
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.00000001).ToString();
                this.TypeBox.Text = "Masa";
            }

                            //GRAMY NA INNE JEDNOSTKI
            if (this.UnitFromBox.Text == "g" && this.UnitToBox.Text == "mg")        //g na mg
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1000).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "g" && this.UnitToBox.Text == "g")        //g na g
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "g" && this.UnitToBox.Text == "dkg")        //g na dkg
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.1).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "g" && this.UnitToBox.Text == "kg")        //g na kg
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.001).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "g" && this.UnitToBox.Text == "T")        //g na Tone
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.000001).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "g" && this.UnitToBox.Text == "funt")        //g na funt
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0022).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "g" && this.UnitToBox.Text == "uncja")        //g na uncje
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.03527).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "g" && this.UnitToBox.Text == "karat")        //g na karaty
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 5).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "g" && this.UnitToBox.Text == "kwintal")        //g na kwintale
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.00001).ToString();
                this.TypeBox.Text = "Masa";
            }

                                //DEKAGRAMY NA INNE JEDNOSTKI
            if (this.UnitFromBox.Text == "dkg" && this.UnitToBox.Text == "mg")        //dkg na mg
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 10000).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "dkg" && this.UnitToBox.Text == "g")        //dkg na g
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 10).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "dkg" && this.UnitToBox.Text == "dkg")        //dkg na dkg
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "dkg" && this.UnitToBox.Text == "kg")        //dkg na kg
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.01).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "dkg" && this.UnitToBox.Text == "T")        //dkg na tone
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.00001).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "dkg" && this.UnitToBox.Text == "funt")        //dkg na funt
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.022).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "dkg" && this.UnitToBox.Text == "uncja")        //dkg na uncje
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.3527).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "dkg" && this.UnitToBox.Text == "karat")        //dkg na karaty
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 50).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "dkg" && this.UnitToBox.Text == "kwintal")        //dkg na kwintale
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.0001).ToString();
                this.TypeBox.Text = "Masa";
            }

                                //KILOGRAMY NA INNE JEDNOSTKI
            if (this.UnitFromBox.Text == "kg" && this.UnitToBox.Text == "mg")        //kg na mg
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1000000).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "kg" && this.UnitToBox.Text == "g")        //kg na g
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1000).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "kg" && this.UnitToBox.Text == "dkg")        //kg na dkg
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 100).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "kg" && this.UnitToBox.Text == "kg")        //kg na kg
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "kg" && this.UnitToBox.Text == "T")        //kg na tone
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.001).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "kg" && this.UnitToBox.Text == "funt")        //kg na funt
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 2.2046).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "kg" && this.UnitToBox.Text == "uncja")        //kg na uncje
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 35.274).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "kg" && this.UnitToBox.Text == "karat")        //kg na karaty
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 5000).ToString();
                this.TypeBox.Text = "Masa";
            }

            if (this.UnitFromBox.Text == "kg" && this.UnitToBox.Text == "kwintal")        //kg na kwintale
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 0.01).ToString();
                this.TypeBox.Text = "Masa";
            }

                                    //TONY NA INNE JEDNOSTKI
            if (this.UnitFromBox.Text == "T" && this.UnitToBox.Text == "mg")        //tona na mg
            {
                this.ConvertedValueBox.Text =
                (int.Parse(this.RawValueBox.Text) * 1000000000).ToString();
                this.TypeBox.Text = "Masa";
            }

           
        }


        private IStatisticsRepository repository;

        public InsertPage(IStatisticsRepository repo)
        {
            this.repository = repo;
            MainWindow.datagrid.ItemsSource = this.repository.GetStatistics();
            InitializeComponent();
            
        }
        

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {



            ToTemperature();
            ToLength();
            ToMass();


            Statistic st = new Statistic()
            {
                DateTime = DateTime.Now,
                ConvertedValue = Convert.ToDouble(this.ConvertedValueBox.Text),
                RawValue = Convert.ToDouble(this.RawValueBox.Text),
                UnitFrom = UnitFromBox.Text,
                UnitTo = UnitToBox.Text,
                Type = TypeBox.Text
            };

            this.repository.AddStatistic(st);
            MainWindow.datagrid.ItemsSource = this.repository.GetStatistics();


            this.Hide();

        }
    }
}
