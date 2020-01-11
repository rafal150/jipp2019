using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Converter.Services
{
    public class LengthConverter : IConverter
    {
        public string Name => "Measures";

        public List<string> Units => new List<string>(new[] { "Milimetres", "Centimetres", "Decimetres", "Metres", "Kilometres", "Miles", 
            "Yards", "Feet", "Inches", "Nautical miles", "Cables"});


        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            decimal unitFromD = value;

            if (unitFrom == "Milimetres")
            {
                if (unitTo == "Centimetres") value = (unitFromD * 0.1m);
                else if (unitTo == "Decimetres") value = (unitFromD * 0.01m);
                else if (unitTo == "Metres") value = (unitFromD * 0.001m);
                else if (unitTo == "Kilometres") value = (unitFromD * 0.0001m);
                else if (unitTo == "Miles") value = (unitFromD / 1609344);
                else if (unitTo == "Yards") value = (unitFromD * 0.00109361m);
                else if (unitTo == "Feet") value = (unitFromD * 0.00328084m);
                else if (unitTo == "Inches") value = (unitFromD * 0.03937m);
                else if (unitTo == "Nautical miles") value = (unitFromD / 1852000);
                else if (unitTo == "Cables") value = (unitFromD * 0.000004556722m);
                else if (unitTo == "Milimetres") value = unitFromD;
            }
            else if (unitFrom == "Centimetres")
            {
                
                if (unitTo == "Milimetres") value = (unitFromD * 10);
                else if (unitTo == "Decimetres") value = (unitFromD * 0.1m);
                else if (unitTo == "Metres") value = (unitFromD * 0.01m);
                else if (unitTo == "Kilometres") value = (unitFromD * 0.001m);
                else if (unitTo == "Miles") value = (unitFromD * 0.0000062137m);
                else if (unitTo == "Yards") value = (unitFromD * 0.0109361m);
                else if (unitTo == "Feet") value = (unitFromD * 0.0328084m);
                else if (unitTo == "Inches") value = (unitFromD * 0.3937m);
                else if (unitTo == "Nautical miles") value = (unitFromD * 0.0000053996m);
                else if (unitTo == "Cables") value = (unitFromD * 0.00004556722m);
                else if (unitTo == "Centimetres") value = unitFromD;
            }
            else if (unitFrom == "Decimetres")
            {
                
                if (unitTo == "Milimetres") value = (unitFromD * 100);
                else if (unitTo == "Centimetres") value = (unitFromD * 10);
                else if (unitTo == "Metres") value = (unitFromD * 0.1m);
                else if (unitTo == "Kilometres") value = (unitFromD * 0.01m);
                else if (unitTo == "Miles") value = (unitFromD * 0.000062137m);
                else if (unitTo == "Yards") value = (unitFromD * 0.109361m);
                else if (unitTo == "Feet") value = (unitFromD * 0.328084m);
                else if (unitTo == "Inches") value = (unitFromD * 3.937m);
                else if (unitTo == "Nautical miles") value = (unitFromD * 0.000053996m);
                else if (unitTo == "Cables") value = (unitFromD * 0.0004556722m);
                else if (unitTo == "Decimetres") value = unitFromD;
            }
            else if (unitFrom == "Metres")
            {
                
                if (unitTo == "Milimetres") value = (unitFromD * 1000);
                else if (unitTo == "Centimetres") value = (unitFromD * 100);
                else if (unitTo == "Decimetres") value = (unitFromD * 10);
                else if (unitTo == "Kilometres") value = (unitFromD * 0.001m);
                else if (unitTo == "Miles") value = (unitFromD * 0.00062137m);
                else if (unitTo == "Yards") value = (unitFromD * 1.09361m);
                else if (unitTo == "Feet") value = (unitFromD * 3.28084m);
                else if (unitTo == "Inches") value = (unitFromD * 39.37m);
                else if (unitTo == "Nautical miles") value = (unitFromD * 0.00053996m);
                else if (unitTo == "Cables") value = (unitFromD * 0.004556722m);
                else if (unitTo == "Metres") value = unitFromD;
            }
            else if (unitFrom == "Kilometres")
            {
                
                if (unitTo == "Milimetres") value = (unitFromD * 1000000);
                else if (unitTo == "Centimetres") value = (unitFromD * 100000);
                else if (unitTo == "Decimetres") value = (unitFromD * 10000);
                else if (unitTo == "Metres") value = (unitFromD * 1000);
                else if (unitTo == "Miles") value = (unitFromD * 0.621371m);
                else if (unitTo == "Yards") value = (unitFromD * 1093.61m);
                else if (unitTo == "Feet") value = (unitFromD * 3280.84m);
                else if (unitTo == "Inches") value = (unitFromD * 39370);
                else if (unitTo == "Nautical miles") value = (unitFromD * 0.53996m);
                else if (unitTo == "Cables") value = (unitFromD * 4.556722m);
                else if (unitTo == "Kilometres") value = unitFromD;
            }
            else if (unitFrom == "Miles")
            {
                
                if (unitTo == "Milimetres") value = (unitFromD * 1609344);
                else if (unitTo == "Centimetres") value = (unitFromD * 160934);
                else if (unitTo == "Decimetres") value = (unitFromD * 16093.4m);
                else if (unitTo == "Metres") value = (unitFromD * 1609.34m);
                else if (unitTo == "Kilometres") value = (unitFromD * 1.60934m);
                else if (unitTo == "Yards") value = (unitFromD * 1760);
                else if (unitTo == "Feet") value = (unitFromD * 5280);
                else if (unitTo == "Inches") value = (unitFromD * 63360);
                else if (unitTo == "Nautical miles") value = (unitFromD * 0.868976m);
                else if (unitTo == "Cables") value = (unitFromD * 8.68m);
                else if (unitTo == "Miles") value = unitFromD;
            }
            else if (unitFrom == "Yards")
            {
                
                if (unitTo == "Milimetres") value = (unitFromD * 914.4m);
                else if (unitTo == "Centimetres") value = (unitFromD * 91.44m);
                else if (unitTo == "Decimetres") value = (unitFromD * 9.144m);
                else if (unitTo == "Metres") value = (unitFromD * 0.9144m);
                else if (unitTo == "Kilometres") value = (unitFromD * 0.0009144m);
                else if (unitTo == "Miles") value = (unitFromD / 1760);
                else if (unitTo == "Feet") value = (unitFromD * 3);
                else if (unitTo == "Inches") value = (unitFromD * 36);
                else if (unitTo == "Nautical miles") value = (unitFromD * 0.000493737m);
                else if (unitTo == "Cables") value = (unitFromD * 0.0049342m);
                else if (unitTo == "Yards") value = unitFromD;
            }
            else if (unitFrom == "Feet")
            {
                
                if (unitTo == "Milimetres") value = (unitFromD * 304.8m);
                else if (unitTo == "Centimetres") value = (unitFromD * 30.48m);
                else if (unitTo == "Decimetres") value = (unitFromD * 3.048m);
                else if (unitTo == "Metres") value = (unitFromD * 0.3048m);
                else if (unitTo == "Kilometres") value = (unitFromD * 0.0003048m);
                else if (unitTo == "Miles") value = (unitFromD / 5280);
                else if (unitTo == "Yards") value = (unitFromD / 3);
                else if (unitTo == "Inches") value = (unitFromD * 12);
                else if (unitTo == "Nautical miles") value = (unitFromD * 0.000164579m);
                else if (unitTo == "Cables") value = (unitFromD * 0.00138889m);
                else if (unitTo == "Feet") value = unitFromD;
            }
            else if (unitFrom == "Inches")
            {
                
                if (unitTo == "Milimetres") value = (unitFromD * 25.4m);
                else if (unitTo == "Centimetres") value = (unitFromD * 2.54m);
                else if (unitTo == "Decimetres") value = (unitFromD * 0.254m);
                else if (unitTo == "Metres") value = (unitFromD * 0.0254m);
                else if (unitTo == "Kilometres") value = (unitFromD * 0.0000254m);
                else if (unitTo == "Miles") value = (unitFromD / 63360);
                else if (unitTo == "Yards") value = (unitFromD / 36);
                else if (unitTo == "Feet") value = (unitFromD / 12);
                else if (unitTo == "Nautical miles") value = ((unitFromD * 127) / 9260000);
                else if (unitTo == "Cables") value = (unitFromD / 7200);
                else if (unitTo == "Inches") value = unitFromD;
            }
            else if (unitFrom == "Nautical miles")
            {
                
                if (unitTo == "Milimetres") value = (unitFromD * 1852000);
                else if (unitTo == "Centimetres") value = (unitFromD * 185200);
                else if (unitTo == "Decimetres") value = (unitFromD * 18520);
                else if (unitTo == "Metres") value = (unitFromD * 1852);
                else if (unitTo == "Kilometres") value = (unitFromD * 1.852m);
                else if (unitTo == "Miles") value = (unitFromD * 1.15078m);
                else if (unitTo == "Yards") value = (unitFromD * 2025.37m);
                else if (unitTo == "Feet") value = (unitFromD * 6076.12m);
                else if (unitTo == "Inches") value = (unitFromD * 72913.4m);
                else if (unitTo == "Cables") value = (unitFromD * 10);
                else if (unitTo == "Nautical miles") value = unitFromD;
            }
            else if (unitFrom == "Cables")
            {
                
                if (unitTo == "Milimetres") value = (unitFromD * 182880);
                else if (unitTo == "Centimetres") value = (unitFromD * 18288);
                else if (unitTo == "Decimetres") value = (unitFromD * 1828.8m);
                else if (unitTo == "Metres") value = (unitFromD * 182.88m);
                else if (unitTo == "Kilometres") value = (unitFromD * 0.18288m);
                else if (unitTo == "Miles") value = (unitFromD / 8.68m);
                else if (unitTo == "Yards") value = (unitFromD * 202.67m);
                else if (unitTo == "Feet") value = (unitFromD * 608);
                else if (unitTo == "Inches") value = (unitFromD * 7291.34m);
                else if (unitTo == "Nautical miles") value = (unitFromD / 10);
                else if (unitTo == "Cables") value = unitFromD;
            }
            return value;
        }
    }
}